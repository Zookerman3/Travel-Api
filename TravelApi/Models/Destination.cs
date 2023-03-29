using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApi.Models
{
    public class Destination
    {

        public int DestinationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}