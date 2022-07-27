using Local_Weather_Server_API.Models;
using MediatR;

namespace Local_Weather_Server_API.Command
{
    public class AddCityCodeCommand: IRequest<CityCode>
    {
        public  CityCode Citycode { get; }

        public AddCityCodeCommand(CityCode citycode)
        {
            Citycode = citycode;

        }
    }
}
