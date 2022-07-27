using Local_Weather_Server_API.Command;
using Local_Weather_Server_API.Models;
using Local_Weather_Server_API.WeatherRepository;
using MediatR;

namespace Local_Weather_Server_API.Handler
{
    public class AddCityCodeHandler : IRequestHandler<AddCityCodeCommand, CityCode>
    {
        private readonly IWeatherforecastRepository _WeatherforecastRepository;

        public AddCityCodeHandler(IWeatherforecastRepository weatherforecastRepository)
        {
            _WeatherforecastRepository = weatherforecastRepository;
        }

        public async Task<CityCode> Handle(AddCityCodeCommand request, CancellationToken cancellationToken)
        {
            return await _WeatherforecastRepository.AddCityCodeAsync(request.Citycode);
        }
    }
}
