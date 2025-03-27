using EventManagement.Entity.Abstract;

namespace EventManagement.Entity.Concrete
{
    public class Event : IEntity
    {
        public Event()
        {
            EventParticipants = new List<EventParticipant>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Detail { get; set; }
        public List<EventParticipant> EventParticipants{ get; set; }
    }
}
