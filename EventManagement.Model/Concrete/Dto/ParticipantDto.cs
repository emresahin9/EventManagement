using EventManagement.Model.Abstract;

namespace EventManagement.Model.Concrete.Dto
{
    public class ParticipantDto : IDto
    {
        public ParticipantDto()
        {
            EventParticipants = new List<EventParticipantDto>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int EventParticipationStatusId { get; set; }
        public EventParticipationStatusDto EventParticipationStatus { get; set; }
        public List<EventParticipantDto> EventParticipants { get; set; }
    }
}
