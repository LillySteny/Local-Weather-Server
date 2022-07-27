using Local_Weather_Server_API.Models;
using Local_Weather_Server_API.Query;
using Local_Weather_Server_API.WeatherRepository;
using MediatR;

namespace Local_Weather_Server_API.Handler
{
    public class GetWeatherbyCityCodeHandler : IRequestHandler<GetWeatherbyCityCode, WeatherData>
    {
        private readonly IWeatherforecastRepository _WeatherforecastRepository;

        public GetWeatherbyCityCodeHandler(IWeatherforecastRepository weatherforecastRepository)
        {
            _WeatherforecastRepository = weatherforecastRepository;

        }
       
        public async Task <WeatherData> Handle(GetWeatherbyCityCode request, CancellationToken cancellationToken)
        {
            var weatherdata = await _WeatherforecastRepository.GetWeatherdataByCode(request.CityCode);
            return weatherdata;
        }
    }
}
