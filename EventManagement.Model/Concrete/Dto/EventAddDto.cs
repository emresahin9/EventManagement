using EventManagement.Model.Abstract;

namespace EventManagement.Model.Concrete.Dto
{
    public class EventAddDto : IDto
    {
        public EventAddDto()
        {
            SelectedParticipantIds = new List<int>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Detail { get; set; }
        public List<int> SelectedParticipantIds { get; set; }
    }
}
