using Local_Weather_Server_API.Models;
using MongoDB.Bson;

namespace Local_Weather_Server_API.WeatherRepository
{
    public interface IWeatherforecastRepository
    {
        Task<List<WeatherData>> GetAllAsync();
        Task<CityCode> AddCityCodeAsync(CityCode citycode);
        WeatherResponse GetForecast(string code);
        Task<WeatherData> CreateAsync(WeatherData model);
        Task DeleteAsync(string code);
        Task<WeatherData> GetWeatherdataByCode(string code);
        Task UpdateByCityCode();
    }
}
