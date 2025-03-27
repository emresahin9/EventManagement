using EventManagement.Model.Abstract;

namespace EventManagement.Model.Concrete.Dto
{
    public class EventParticipantDto : IDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public EventDto Event { get; set; }
        public int ParticipantId { get; set; }
        public ParticipantDto Participant { get; set; }
    }
}
