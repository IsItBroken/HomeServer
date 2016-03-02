using Microsoft.Data.Entity;

namespace TestApi.Models
{
    public class AppDbContext : DbContext
    {
        private static bool _created = false;

        public AppDbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        public DbSet<TemperatureReading> TemperatureReadings { get; set; } 
    }
}