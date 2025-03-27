using EventManagement.Model.Abstract;

namespace EventManagement.Model.Concrete.Dto
{
    public class EventParticipationStatusDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}