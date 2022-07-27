using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Local_Weather_Server_API.Models
{
    public class CityCode
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public  ObjectId Id { get; set; } 
        public string citycode { get; set; }= String.Empty;
    }
}
