using Local_Weather_Server_API.Models;
using MediatR;

namespace Local_Weather_Server_API.Command
{
    public class DeleteWeatherDataCommand: IRequest<string>
    {
        public string _citycode { get; set; }

        public DeleteWeatherDataCommand(string citycode)
        {
            _citycode = citycode;
        }
    }
}
