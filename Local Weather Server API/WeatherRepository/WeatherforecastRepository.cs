using Local_Weather_Server_API.Config;
using Local_Weather_Server_API.Models;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Local_Weather_Server_API.WeatherRepository
{
    public class WeatherforecastRepository : IWeatherforecastRepository, IRequest<WeatherResponse>
    {
        public string cityCode="";
        private readonly IWeatherforecastRepository _weatherforecastRepository;
        private readonly IMongoCollection<WeatherData> _weatherData;
        private readonly IMongoCollection<CityCode> _citycode;

        private readonly MongoDBConnectionstring _settings;

        public WeatherforecastRepository(IOptions<MongoDBConnectionstring> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _weatherData = database.GetCollection<WeatherData>(_settings.WeatherCollectionName);
            _citycode = database.GetCollection<CityCode>("CityCode");
        }

        public WeatherResponse GetForecast(string code)
        {
            var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?id={code}&appid=ba8b8bdcdbbffbe7986cde20f4dc5ccb");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                return content.ToObject<WeatherResponse>();
            }

            return null;
        }

        public async Task<CityCode> AddCityCodeAsync(CityCode citycode)
        {
            await _citycode.InsertOneAsync(citycode);
            return citycode;
        }

        public async Task<WeatherData> CreateAsync(WeatherData model)
        {          
            await _weatherData.InsertOneAsync(model);
            return model;
        }

        public async Task DeleteAsync(string code)
        {
            await _weatherData.DeleteOneAsync(c => c.Code == code);
        }

        public async Task<List<WeatherData>> GetAllAsync()
        {

            return await _weatherData.Find(c => true).ToListAsync();
        }

        public async Task UpdateByCityCode()
        {

            var citycode = _citycode.Find(c => true).ToList();
            foreach (var city in citycode)
            {
                string code = city.citycode;
                WeatherData model = _weatherData.Find(c => c.Code == code).FirstOrDefault();
                WeatherResponse weatherResponse = new WeatherResponse();
                weatherResponse = GetForecast(code);
                if (weatherResponse != null)
                {
                    model.Code = code;
                    model.Name = weatherResponse.Name;
                    model.Humidity = weatherResponse.Main.Humidity;
                    model.Pressure = weatherResponse.Main.Pressure;
                    model.Temperature = weatherResponse.Main.Temp;
                    model.WeatherDescription = weatherResponse.Weather[0].Description;
                    model.Wind = weatherResponse.Wind.Speed;
                }
               await _weatherData.ReplaceOneAsync(c => c.Code == code, model);
               
            }
        }

        public  Task<WeatherData> GetWeatherdataByCode(string code)
        {
            
            return _weatherData.Find<WeatherData>(c => c.Code == code).FirstOrDefaultAsync();
        }
    }
}
