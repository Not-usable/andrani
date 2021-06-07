using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.OpenStreetMaps
{
    public class OpenStreetMapsResponse
    {
        [JsonPropertyName("lat")]
        public string Latitude { get; set; }
        [JsonPropertyName("lon")]
        public string Longitude { get; set; }
    }
}
