using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Local_Weather_Server_API.Models
{
    public class WeatherData
    {
        [BsonId]
       // [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [Display(Name = "City Code")]
        public string Code { get; set; }

        [Display(Name="City Name")]
        public string Name { get; set; }

        [Display(Name = "Temp")]
        public float Temperature { get; set; }

        [Display(Name = "Humidity")]
        public int Humidity { get; set; }

        [Display(Name = "Pressure")]
        public int Pressure { get; set; }

        [Display(Name = "Wind Speed")]
        public float Wind { get; set; }

        [Display(Name = "Weather Condition")]
        public string WeatherDescription { get; set; }

    }
}
