using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TestApi.Models;
using TestApi.Repository;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    public class TemperatureController : Controller
    {
        private readonly ITemperatureReadingRepository _temperatureReadingRepository;

        public TemperatureController(ITemperatureReadingRepository temperatureReadingRepository)
        {
            _temperatureReadingRepository = temperatureReadingRepository;
        }

        [HttpGet]
        public IEnumerable<TemperatureReading> GetAll()
        {
            return _temperatureReadingRepository.GetAll();
        }

        [HttpPost]
        public IActionResult Add([FromBody] TemperatureReading item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }

            item.MeasurementTime = DateTime.Now;
            _temperatureReadingRepository.Add(item);
            return Ok();
        }
    }
}