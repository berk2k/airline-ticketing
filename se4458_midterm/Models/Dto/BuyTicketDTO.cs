using System.ComponentModel.DataAnnotations;

namespace se4458_midterm.Models.Dto
{
    public class BuyTicketDTO
    {
        [Required]
        public int FlightNumber { get; set; }

        public DateTime Date { get; set; }

        public string From { get; set; }

        public string To { get; set; }
        public string FullName { get; set; }
    }
}
