using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain.POCO
{
    public class SoldTicket
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int SessionId { get; set; }
        //public int Quantity { get; set; }
        public Account Account { get; set; }
        public Session Session { get; set; }
    }
}
