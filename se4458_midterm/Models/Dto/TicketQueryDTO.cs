using Microsoft.AspNetCore.Mvc;

namespace se4458_midterm.Models.Dto
{
    public class TicketQueryDTO
    {

        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int NumberOfPeople { get; set; }


    }
}
