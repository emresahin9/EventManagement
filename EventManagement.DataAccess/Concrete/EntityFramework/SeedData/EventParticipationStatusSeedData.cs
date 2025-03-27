using EventManagement.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.DataAccess.Concrete.EntityFramework.SeedData
{
    internal class EventParticipationStatusSeedData
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipationStatus>().HasData(
               new EventParticipationStatus { Id = 1, Name = "Müsait" },
               new EventParticipationStatus { Id = 2, Name = "Müsait Değil" }
            );
        }
    }
}
