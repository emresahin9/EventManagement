using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EventManagement.Entity.Concrete;

namespace EventManagement.DataAccess.Concrete.EntityFramework.Configurations
{
    internal class EventParticipationStatusConfiguration : IEntityTypeConfiguration<EventParticipationStatus>
    {
        public void Configure(EntityTypeBuilder<EventParticipationStatus> builder)
        {
            builder.ToTable("EventParticipationStatuses", "dbo");
            builder.HasKey(x => x.Id);

        }
    }
}