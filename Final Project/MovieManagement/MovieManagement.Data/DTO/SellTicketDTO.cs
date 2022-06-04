using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Data.DTO
{
    public class SellTicketDTO
    {
        public int SessionId { get; set; }
        public int AccountId { get; set; }
        //public int Quantity { get; set; }
    }
}
