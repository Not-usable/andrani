namespace Application.Interfaces.MessageQueue
{
    public class GeoResponseMessage
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
