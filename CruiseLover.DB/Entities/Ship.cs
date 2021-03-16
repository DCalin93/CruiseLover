using System.ComponentModel.DataAnnotations;

namespace CruiseLover.DB.Entities
{
    public class Ship
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public CruiseDetail CruiseDetail { get; set; }
    }
}
