using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain.POCO
{
    public class Account : IdentityUser
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public string UserName { get; set; }

        //public string Email { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }
        public string Role { get; set; }

        public List<SoldTicket> SoldTickets { get; set; }
        public List<BookedTicket> BookedTickets { get; set; }
    }
}
