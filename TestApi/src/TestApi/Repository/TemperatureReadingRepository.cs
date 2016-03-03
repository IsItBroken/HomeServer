using System.Collections.Generic;
using System.Linq;
using TestApi.Models;

namespace TestApi.Repository
{
    public class TemperatureReadingRepository : ITemperatureReadingRepository
    {
        static AppDbContext _context;

        public TemperatureReadingRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TemperatureReading item)
        {
            _context.TemperatureReadings.Add(item);
        }

        public IEnumerable<TemperatureReading> GetAll()
        {
            return _context.TemperatureReadings;
        }

        public TemperatureReading Find(int id)
        {
            return _context.TemperatureReadings.SingleOrDefault(t => t.Id == id);
        }

        public void Remove(int id)
        {
            var itemToRemove = _context.TemperatureReadings.SingleOrDefault(t => t.Id == id);
            if (itemToRemove != null)
                _context.TemperatureReadings.Remove(itemToRemove);
        }

        public void Update(TemperatureReading item)
        {
            var itemToUpdate = _context.TemperatureReadings.SingleOrDefault(t => t.Id == item.Id);
            if (itemToUpdate == null) return;

            itemToUpdate.Temperature = item.Temperature;
            itemToUpdate.Humidity = item.Humidity;
            itemToUpdate.HeatIndex = item.HeatIndex;
            itemToUpdate.MeasurementTime = item.MeasurementTime;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}