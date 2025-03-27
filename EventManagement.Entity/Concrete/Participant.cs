using EventManagement.Entity.Abstract;

namespace EventManagement.Entity.Concrete
{
    public class Participant : IEntity
    {
        public Participant()
        {
            EventParticipants = new List<EventParticipant>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int EventParticipationStatusId { get; set; }
        public EventParticipationStatus EventParticipationStatus { get; set; }
        public List<EventParticipant> EventParticipants { get; set; }
    }
}
