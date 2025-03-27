using EventManagement.Model.Abstract;

namespace EventManagement.Model.Concrete.Dto
{
    public class EventDto : IDto
    {
        public EventDto()
        {
            EventParticipants = new List<EventParticipantDto>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Detail { get; set; }
        public List<EventParticipantDto> EventParticipants{ get; set; }
    }
}
