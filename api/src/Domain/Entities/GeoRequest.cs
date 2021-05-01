using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class GeoRequest
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("calle")]
        public string Street { get; set; }
        [JsonPropertyName("numero")]
        public int Number { get; set; }
        [JsonPropertyName("ciudad")]
        public string City { get; set; }
        [JsonPropertyName("codigo_postal")]
        public string PostalCode{ get; set; }
        [JsonPropertyName("provincia")]
        public string Province { get; set; }
        [JsonPropertyName("pais")]
        public string State { get; set; }
        [JsonPropertyName("latitud")]
        public string Latitude { get; set; }
        [JsonPropertyName("longitud")]
        public string Longitude { get; set; }
        [JsonPropertyName("estado")]
        public string Status { get; set; }
    }
}
