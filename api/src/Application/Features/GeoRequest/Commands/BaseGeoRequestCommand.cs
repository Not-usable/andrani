using System.ComponentModel.DataAnnotations;

namespace Application.Features.GeoRequest.Commands
{
    public abstract class BaseGeoRequestCommand
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        public double Discount { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public bool SoldOut { get; set; }
    }
}
