using System.Collections.Generic;
using TestApi.Models;

namespace TestApi.Repository
{
    public interface ITemperatureReadingRepository
    {
        void Add(TemperatureReading item);
        IEnumerable<TemperatureReading> GetAll();
        TemperatureReading Find(int id);
        void Remove(int id);
        void Update(TemperatureReading item);
    }
}