using EventManagement.Entity.Abstract;

namespace EventManagement.Entity.Concrete
{
    public class EventParticipant : IEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
