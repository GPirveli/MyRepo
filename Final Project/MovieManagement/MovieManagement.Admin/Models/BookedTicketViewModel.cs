using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Admin.Models
{
    public class BookedTicketViewModel
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public string AccountId { get; set; }
        public int MovieId { get; set; }
    }
}
