namespace Local_Weather_Server_API.Models
{
    public class WeatherResponse
    {
        public List<Weather> Weather { get;set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public string Name { get; set; }=String.Empty;
        public string Code { get; set; }=String.Empty;

    }
}
