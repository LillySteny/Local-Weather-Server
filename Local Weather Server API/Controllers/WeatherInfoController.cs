using Local_Weather_Server_API.Command;
using Local_Weather_Server_API.Models;
using Local_Weather_Server_API.Query;
using Local_Weather_Server_API.WeatherRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Local_Weather_Server_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
         private readonly IWeatherforecastRepository _weatherforecastRepository;

        public WeatherInfoController(IMediator mediator, IWeatherforecastRepository weatherforecastRepository)
        {
            _mediator = mediator;
            _weatherforecastRepository = weatherforecastRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddCityCode(CityCode cityCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Code= await _mediator.Send(new AddCityCodeCommand(cityCode));
            return Code != null ? Created($"/product/{Code.Id}", Code) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var weatherdatas = await _mediator.Send(new GetAllWeatherData());
            return Ok(weatherdatas);
        }
     
        [HttpGet("{code}")]
        public async  Task<IActionResult> Get(string code)
        {
            return Ok(await _weatherforecastRepository.GetWeatherdataByCode(code));

        }

        [HttpPost("{code}")]
        public async Task<IActionResult> Create(WeatherData weatherData,string code)
        {
            WeatherResponse weatherResponse = _weatherforecastRepository.GetForecast(code);
            if (weatherResponse != null)
            {
                weatherData.Code = code;
                weatherData.Name = weatherResponse.Name;
                weatherData.Humidity = weatherResponse.Main.Humidity;
                weatherData.Pressure = weatherResponse.Main.Pressure;
                weatherData.Temperature = weatherResponse.Main.Temp;
                weatherData.WeatherDescription = weatherResponse.Weather[0].Description;
                weatherData.Wind = weatherResponse.Wind.Speed;
            }
            var Code = await _mediator.Send(new AddWeatherDataCommand(weatherData));
            return Code != null ? Created($"/product/{weatherData.Id}", Code) : BadRequest();
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var weatherData = await _mediator.Send(new DeleteWeatherDataCommand(code));
            if (weatherData == null)
            {
                return NotFound();
            }                   
           return NoContent();
        }
    }
}
