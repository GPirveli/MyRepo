using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain.POCO
{
    public class Session
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsActive { get; set; }
        public Movie Movie { get; set; }
        public List<SoldTicket> SoldTickets { get; set; }
        public List<BookedTicket> BookedTickets { get; set; }
    }
}
