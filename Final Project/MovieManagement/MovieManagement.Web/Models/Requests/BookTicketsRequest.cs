using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Web.Models.Requests
{
    public class BookTicketsRequest
    {
        public string AccountId { get; set; }
        public int SessionId { get; set; }
    }
}
