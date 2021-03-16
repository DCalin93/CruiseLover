using System.ComponentModel.DataAnnotations;

namespace CruiseLover.DB.Entities
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CruiseDetail CruiseDetail { get; set; }
    }
}