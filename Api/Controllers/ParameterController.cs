using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParameterController : ControllerBase
    {
        private IConfiguration _configuration;

        public ParameterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult GetParameter()
        {

            string parameter1 = _configuration["test-key"];
            string parameter2 = _configuration["test-key2"];
            string parameter3 = _configuration["test-key3"];

            return Ok(new List<string> { parameter1, parameter2, parameter3 });

        }

    }
}