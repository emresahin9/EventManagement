using EventManagement.Business.Abstract;
using EventManagement.Model.Concrete.Dto;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections;

namespace EventManagement.WebUI.Filters.ExceptionFilters
{
    public class ValidationExceptionFilter : IExceptionFilter, IActionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly ITempDataDictionaryFactory _tempDataFactory;
        private readonly ValidationType _validationType;
        private readonly IEventParticipationStatusService _eventParticipationStatusService;
        private readonly IParticipantService _participantService;

        public ValidationExceptionFilter(IModelMetadataProvider modelMetadataProvider, ITempDataDictionaryFactory tempDataFactory, IEventParticipationStatusService eventParticipationStatusService, IParticipantService participantService, ValidationType validationType = 0)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _tempDataFactory = tempDataFactory;
            _validationType = validationType;
            _eventParticipationStatusService = eventParticipationStatusService;
            _participantService = participantService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["ActionArguments"] = context.ActionArguments;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException ex)
            {
                var tempData = _tempDataFactory.GetTempData(context.HttpContext);
                var viewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                IDictionary arguments;

                switch (_validationType)
                {
                    case ValidationType.EventAdd:
                        arguments = context.HttpContext.Items["ActionArguments"] as IDictionary;
                        var _eventAdd = arguments["model"] as EventAddDto;
                        tempData.Add("Participants", _participantService.GetAllAvailable());
                        viewData.Model = _eventAdd;
                        break; 
                    case ValidationType.EventUpdate:
                        arguments = context.HttpContext.Items["ActionArguments"] as IDictionary;
                        var _eventUpdate = arguments["model"] as EventDto;
                        viewData.Model = _eventUpdate;
                        break;
                    case ValidationType.Participant:
                        arguments = context.HttpContext.Items["ActionArguments"] as IDictionary;
                        var participant = arguments["model"] as ParticipantDto;
                        tempData.Add("EventParticipationStatuses", _eventParticipationStatusService.GetAll());
                        viewData.Model = participant;
                        break;
                    
                }

                var validationResult = new ValidationResult(ex.Errors);

                foreach (var error in validationResult.Errors)
                {
                    if (context.ModelState.ContainsKey(error.PropertyName))
                    {
                        context.ModelState.Remove(error.PropertyName);

                        context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                context.Result = new ViewResult
                {
                    ViewData = viewData,
                    TempData = tempData,
                    StatusCode = 422,
                };
                context.ExceptionHandled = true;
            }
        }

    }

    public enum ValidationType
    {
        Null = 0,
        EventAdd = 1,
        EventUpdate = 2,
        Participant = 3
    }
}
