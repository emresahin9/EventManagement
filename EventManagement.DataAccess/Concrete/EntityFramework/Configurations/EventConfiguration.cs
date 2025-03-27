using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EventManagement.Entity.Concrete;

namespace EventManagement.DataAccess.Concrete.EntityFramework.Configurations
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Location).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Detail).IsRequired().HasMaxLength(500);

        }
    }
}