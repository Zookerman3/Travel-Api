using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApi.Models
{
    public class Destination
    {

        public int DestinationId { get; set; }
        [Required]
        [StringLength(20)]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
    }
}