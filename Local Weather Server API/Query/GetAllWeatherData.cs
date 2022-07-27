using Local_Weather_Server_API.Models;
using MediatR;

namespace Local_Weather_Server_API.Query
{
    public class GetAllWeatherData: IRequest<List<WeatherData>> { }
  
}
