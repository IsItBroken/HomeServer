using System.Collections.Generic;
using System.Linq;
using TestApi.Models;

namespace TestApi.Repository
{
    public class TemperatureReadingRepository : ITemperatureReadingRepository
    {
        static readonly List<TemperatureReading> TemperatureList = new List<TemperatureReading>();

        public void Add(TemperatureReading item)
        {
            TemperatureList.Add(item);
        }

        public IEnumerable<TemperatureReading> GetAll()
        {
            return TemperatureList;
        }

        public TemperatureReading Find(int id)
        {
            return TemperatureList.SingleOrDefault(t => t.Id == id);
        }

        public void Remove(int id)
        {
            var itemToRemove = TemperatureList.SingleOrDefault(t => t.Id == id);
            if (itemToRemove != null)
                TemperatureList.Remove(itemToRemove);
        }

        public void Update(TemperatureReading item)
        {
            var itemToUpdate = TemperatureList.SingleOrDefault(t => t.Id == item.Id);
            if (itemToUpdate == null) return;

            itemToUpdate.Temperature = item.Temperature;
            itemToUpdate.Humidity = item.Humidity;
            itemToUpdate.HeatIndex = item.HeatIndex;
            itemToUpdate.MeasurementTime = item.MeasurementTime;
        }
    }
}