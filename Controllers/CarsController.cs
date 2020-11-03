using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarManagement.Models;

namespace CarManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private static readonly string[] CarTypes = new[]
        {
            "Polo", "Golf", "Passat", "Tiguan", "Caddy", "Touareg", "T-Roc", "Arteon", "Sharan", "T-cross"
        };
        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Car
            {
                Id = rng.Next(0, 55),
                Brand = "Volkswagen",
                CarRegistrationDate = DateTime.Now.AddDays(index),
                Model = CarTypes[rng.Next(CarTypes.Length)]
            })
            .ToArray();
        }
    }
}
