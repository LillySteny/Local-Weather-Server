using System.ComponentModel.DataAnnotations;

namespace Local_Weather_Server_API.Models
{
    public class City
    {
        [Display(Name = "City Code")]
        public string Code { get; set; }
    }
}
