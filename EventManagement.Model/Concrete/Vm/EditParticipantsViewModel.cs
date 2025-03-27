using EventManagement.Model.Abstract;
using EventManagement.Model.Concrete.Dto;

namespace EventManagement.Model.Concrete.Vm
{
    public class EditParticipantsViewModel : IVm
    {
        public EditParticipantsViewModel()
        {
            Participants = new List<ParticipantOnlyNameDto>();
            SelectedParticipantIds = new List<int>();
        }
        public int EventId { get; set; }
        public List<ParticipantOnlyNameDto> Participants{ get; set; }
        public List<int> SelectedParticipantIds { get; set; }
    }
}
