using EventManagement.Model.Concrete.Dto;
using FluentValidation;

namespace EventManagement.Business.Utilities.Validation.FluentValidation.Rules
{
    public class ParticipantDtoValidator : AbstractValidator<ParticipantDto>
    {
        public ParticipantDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad boş bırakılamaz!");
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("Ad 50 karakterden uzun olamaz!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad boş bırakılamaz!");
            RuleFor(x => x.LastName).MaximumLength(50).WithMessage("Soyad 50 karakterden uzun olamaz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Eposta boş bırakılamaz!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen eposta formatına uygun yazınız!");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Eposta 50 karakterden uzun olamaz!");
            RuleFor(x => x.EventParticipationStatusId).NotEmpty().WithMessage("Etkinlik Katılım Durumu seçilmek zorunda!");
        }
    }
}
