using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Web.Models.Requests
{
    public class CreatePersonRequest
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public int? BirthYear { get; set; }
        public int GenderId { get; set; }
        public bool IsActive { get; set; }
    }
}
