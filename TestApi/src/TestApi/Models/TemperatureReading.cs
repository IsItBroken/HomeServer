using System;

namespace TestApi.Models
{
    public class TemperatureReading
    {
        public int Id { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float HeatIndex { get; set; }
        public DateTime MeasurementTime { get; set; } 
    }
}