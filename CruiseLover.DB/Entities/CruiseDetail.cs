using System;
using System.ComponentModel.DataAnnotations;

namespace CruiseLover.DB.Entities
{
    public class CruiseDetail
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Itinerary { get; set; }
        public int Nights { get; set; }
        public DateTime DepartureDate { get; set; }
        public bool HasDiscount { get; set; }
        public double Discount { get; set; }
        public Ship Ship { get; set; }
        public int ShipId { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }
    }
}
