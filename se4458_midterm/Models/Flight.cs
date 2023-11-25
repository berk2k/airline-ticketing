using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace se4458_midterm.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int FlightNumber { get; set; }

        [Required]
        public DateTime DepartureDate {  get; set; }

        
        public int Capacity {  get; set; }

        
        public int AvailableSeats { get; set; }

        public string Departure { get; set; }
        public string Destination { get; set; }

        public double Price {  get; set; } 
    }
}
