using EventManagement.Entity.Abstract;

namespace EventManagement.Entity.Concrete
{
    public class EventParticipationStatus : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}