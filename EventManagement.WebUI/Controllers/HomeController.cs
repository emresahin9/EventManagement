using Microsoft.AspNetCore.Mvc;
using EventManagement.Business.Abstract;
using EventManagement.WebUI.Filters.ExceptionFilters;
using EventManagement.Model.Concrete.Dto;
using EventManagement.Model.Concrete.Vm;

namespace EventManagement.Controllers;

public class HomeController : Controller
{
    private readonly IEventService _eventService;
    private readonly IParticipantService _participantService;
    private readonly IEventParticipationStatusService _eventParticipationStatusService;

    public HomeController(IEventService eventService, IParticipantService participantService, IEventParticipationStatusService eventParticipationStatusService)
    {
        _eventService = eventService;
        _participantService = participantService;
        _eventParticipationStatusService = eventParticipationStatusService;
    }

    #region Events
    public IActionResult Index()
    {
        return View(_eventService.GetAll());
    }

    public IActionResult AddEvent()
    {
        TempData["Participants"] = _participantService.GetAllAvailable();
        return View();
    }

    [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.EventAdd })]
    [HttpPost]
    public IActionResult AddEvent(EventAddDto model)
    {
        _eventService.Add(model);
        TempData["IsTransactionCompleted"] = true;
        return RedirectToAction("Index");
    }

    public IActionResult EventDetail(int id)
    {
        return View(_eventService.GetById(id));
    }
    
    public IActionResult _EventUpdate(int id)
    {
        var model = _eventService.GetById(id);
        return PartialView(model);
    }

    [HttpPost]
    [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.EventUpdate })]
    public IActionResult _EventUpdate(EventDto model)
    {
        _eventService.Update(model);

        return Ok();
    }

    public IActionResult _EventParticipiantsEdit(int id)
    {
        var model = _eventService.GetEditParticipants(id);
        return PartialView(model);
    }

    [HttpPost]
    public IActionResult _EventParticipiantsEdit(EditParticipantsViewModel model)
    {
        _eventService.UpdateEventParticipants(model);

        return Ok();
    }

    public IActionResult DeleteEvent(int id)
    {
        _eventService.DeleteById(id);

        TempData["IsTransactionCompleted"] = true;
        return RedirectToAction("Index");
    }
    #endregion

    #region Participants
    public IActionResult AllParticipants()
    {
        return View(_participantService.GetAll());
    }

    public IActionResult AddParticipant()
    {
        TempData["EventParticipationStatuses"] = _eventParticipationStatusService.GetAll();
        return View();
    }

    [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.Participant })]
    [HttpPost]
    public IActionResult AddParticipant(ParticipantDto model)
    {
        _participantService.Add(model);
        TempData["IsTransactionCompleted"] = true;
        return RedirectToAction("AllParticipants");
    }
    public IActionResult UpdateParticipant(int id)
    {
        var model = _participantService.GetById(id);
        TempData["EventParticipationStatuses"] = _eventParticipationStatusService.GetAll();
        return View(model);
    }

    [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.Participant })]
    [HttpPost]
    public IActionResult UpdateParticipant(ParticipantDto model)
    {
        _participantService.Update(model);
        TempData["IsTransactionCompleted"] = true;
        return RedirectToAction("AllParticipants");
    }

    public IActionResult DeleteParticipant(int id)
    {
        _participantService.DeleteById(id);

        TempData["IsTransactionCompleted"] = true;
        return RedirectToAction("AllParticipants");
    }
    #endregion

    public IActionResult CompleteTransaction(string route)
    {
        TempData["IsTransactionCompleted"] = true;
        return RedirectToAction(route);
    }
}
