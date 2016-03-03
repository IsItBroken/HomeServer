using Microsoft.Data.Entity;

namespace TestApi.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<TemperatureReading> TemperatureReadings { get; set; } 
    }
}