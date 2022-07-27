using Local_Weather_Server_API.Models;
using MediatR;

namespace Local_Weather_Server_API.Command
{
    public class AddWeatherDataCommand: IRequest<WeatherData>
    {
       public WeatherData _weatherData { get; }
       
        public AddWeatherDataCommand(WeatherData weatherData)
        {
            _weatherData = weatherData;
        }
    }
}
