using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Demo.RequestValidators;
using ExpressGlobalExceptionHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Get(BindModel data)
        {
            throw new Exception();
            var result = new List<string> { "Data A", "Data B" };
            //Validate request
            if (WeatherForecastValidator.ValidateGet(data).IsSuccess)
            {
                return Ok(new Response<List<string>>
                {
                    Data = result
                });
            }
            else
            {
                return BadRequest(WeatherForecastValidator.ValidateGet(data));
            }            
        }
    }
}
