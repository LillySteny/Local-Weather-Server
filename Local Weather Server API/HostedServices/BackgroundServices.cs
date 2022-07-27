using Local_Weather_Server_API.Models;
using Local_Weather_Server_API.WeatherRepository;
using MongoDB.Bson;


namespace Local_Weather_Server_API.HostedServices
{
    public class BackgroundServices : BackgroundService
    {
        private readonly IWeatherforecastRepository _weatherforecastRepository;
        private readonly ILogger<BackgroundServices> _logger;
        public IServiceProvider Services { get; }

        public BackgroundServices(IServiceProvider services,
        ILogger<BackgroundServices> logger, IWeatherforecastRepository weatherforecastRepository)
        {
            Services = services;
            _logger = logger;
            _weatherforecastRepository = weatherforecastRepository;
        }


        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {         
            while (!stoppingToken.IsCancellationRequested)
            {
                    await _weatherforecastRepository.UpdateByCityCode();
                    await Task.Delay(1000 * 60 * 30, stoppingToken);
                }
               
            

        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping Background Service");
            await base.StopAsync(cancellationToken);
        }
    }
}
