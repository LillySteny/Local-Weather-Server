using Local_Weather_Server_API.Command;
using Local_Weather_Server_API.Models;
using Local_Weather_Server_API.WeatherRepository;
using MediatR;

namespace Local_Weather_Server_API.Handler
{
    public class AddWeatherDataCommandHandler : IRequestHandler<AddWeatherDataCommand, WeatherData>
    {
        private readonly IWeatherforecastRepository _WeatherforecastRepository;

        public AddWeatherDataCommandHandler(IWeatherforecastRepository weatherforecastRepository)
        {
            _WeatherforecastRepository = weatherforecastRepository;
        }

        public async Task<WeatherData> Handle(AddWeatherDataCommand request, CancellationToken cancellationToken)
        {

            return await _WeatherforecastRepository.CreateAsync(request._weatherData);
        }
    }
}
