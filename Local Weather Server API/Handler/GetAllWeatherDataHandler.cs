using Local_Weather_Server_API.Models;
using Local_Weather_Server_API.Query;
using Local_Weather_Server_API.WeatherRepository;
using MediatR;

namespace Local_Weather_Server_API.Handler
{
    public class GetAllWeatherDataHandler : IRequestHandler<GetAllWeatherData, List<WeatherData>>
    {
        private readonly IWeatherforecastRepository _WeatherforecastRepository;

        public GetAllWeatherDataHandler(IWeatherforecastRepository weatherforecastRepository)
        {
            _WeatherforecastRepository = weatherforecastRepository; 
        }

        public async Task<List<WeatherData>> Handle(GetAllWeatherData request, CancellationToken cancellationToken)
        {
            var weatherdata = await _WeatherforecastRepository.GetAllAsync();
            return weatherdata;
        }
    }
}
