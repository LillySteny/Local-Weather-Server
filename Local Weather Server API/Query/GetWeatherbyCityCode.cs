using Local_Weather_Server_API.Models;
using MediatR;

namespace Local_Weather_Server_API.Query
{
    public class GetWeatherbyCityCode: IRequest<WeatherData> 
    { 
        public string CityCode { get;}

        public GetWeatherbyCityCode(string cityCode)
        {
            CityCode = cityCode;
        }
    }
  
}
