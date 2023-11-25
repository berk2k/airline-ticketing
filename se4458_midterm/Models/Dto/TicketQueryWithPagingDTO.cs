namespace se4458_midterm.Models.Dto
{
    public class TicketQueryWithPagingDTO
    {
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int NumberOfPeople { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
        //const int maxPageSize = 10;
        //public int PageNumber { get; set; } = 1;
        //private int _pageSize = 5;
        //public int PageSize
        //{
        //    get
        //    {
        //        return _pageSize;
        //    }
        //    set
        //    {
        //        _pageSize = (value > maxPageSize) ? maxPageSize : value;
        //    }
        //}





    }
}
