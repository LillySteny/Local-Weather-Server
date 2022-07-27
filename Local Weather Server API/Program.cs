using MediatR;
using Local_Weather_Server_API.WeatherRepository;
using Local_Weather_Server_API.Config;
using Local_Weather_Server_API.HostedServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDBConnectionstring>(
    builder.Configuration.GetSection("WeatherConnectionSettings")
);
builder.Services.AddSingleton<IWeatherforecastRepository, WeatherforecastRepository>();
builder.Services.AddHttpClient();
builder.Services.AddHostedService<BackgroundServices>();
builder.Services.AddMediatR(typeof(WeatherforecastRepository).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
