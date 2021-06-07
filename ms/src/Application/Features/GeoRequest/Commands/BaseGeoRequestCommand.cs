using System.ComponentModel.DataAnnotations;

namespace Application.Features.GeoRequest.Commands
{
    public abstract class BaseGeoRequestCommand
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string State { get; set; }
    }
}
