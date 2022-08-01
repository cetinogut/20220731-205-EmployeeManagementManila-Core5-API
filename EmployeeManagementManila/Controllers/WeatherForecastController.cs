using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementManila.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //private readonly ILoggerManager _logger;

        //private readonly ILogger<WeatherForecastController> _logger;
        //public WeatherForecastController(ILoggerManager logger)
        //{
        //    _logger = logger;
        //}

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}



        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    _logger.LogInformation("Here is information message from the controller.");
        //    _logger.LogDebug("Here is debug message from the controller.");
        //    _logger.LogWarning("Here is warning message from the controller.");
        //    _logger.LogError("Here is error message from the controller.");
        //    return new string[] { "value1", "value2" };
        //}

        private IRepositoryWrapper _repository;
        public WeatherForecastController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var staff2Accounts = _repository.Account.FindByCondition(x => x.AccountType.Equals("Staff-2"));
            var employees = _repository.Employee.FindAll();
            return new string[] { "value1", "value2" };
        }
    }
}
