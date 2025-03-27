using EventManagement.Model.Concrete.Dto;
using FluentValidation;

namespace EventManagement.Business.Utilities.Validation.FluentValidation.Rules
{
    public class EventAddDtoValidator : AbstractValidator<EventAddDto>
    {
        public EventAddDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz!");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık 100 karakterden uzun olamaz!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih seçilmeli!");
            RuleFor(x => x.Date).GreaterThanOrEqualTo(DateTime.Today.AddDays(1)).WithMessage("Tarih en erken yarın olmalıdır.");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Yer boş bırakılamaz!");
            RuleFor(x => x.Location).MaximumLength(100).WithMessage("Yer 100 karakterden uzun olamaz!");
            RuleFor(x => x.Detail).NotEmpty().WithMessage("Detay boş bırakılamaz!");
            RuleFor(x => x.Detail).MaximumLength(500).WithMessage("Detay 500 karakterden uzun olamaz!");
        }
    }
}
