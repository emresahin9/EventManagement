using EventManagement.DataAccess.Concrete.EntityFramework.Configurations;
using EventManagement.DataAccess.Concrete.EntityFramework.SeedData;
using EventManagement.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.DataAccess.Concrete.EntityFramework.Contexts
{
    public class EventManagementContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EventManagementDatabase;Trusted_Connection=True");
        }

        public DbSet<Event> Events{ get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<EventParticipationStatus> EventParticipationStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new EventParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new EventParticipationStatusConfiguration());

            new EventParticipationStatusSeedData().Seed(modelBuilder);
        }
    }
}
