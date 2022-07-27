using Local_Weather_Server_API.Command;
using Local_Weather_Server_API.WeatherRepository;
using MediatR;

namespace Local_Weather_Server_API.Handler
{
    public class DeleteWeatherDataCommandHandler : IRequestHandler<DeleteWeatherDataCommand, string>
    {
        private readonly IWeatherforecastRepository _WeatherforecastRepository;

        public DeleteWeatherDataCommandHandler(IWeatherforecastRepository weatherforecastRepository)
        {
            _WeatherforecastRepository = weatherforecastRepository;

        }
        public async Task<string> Handle(DeleteWeatherDataCommand request, CancellationToken cancellationToken)
        {
            await _WeatherforecastRepository.DeleteAsync(request._citycode);
            return request._citycode;           
        }
    }
}
