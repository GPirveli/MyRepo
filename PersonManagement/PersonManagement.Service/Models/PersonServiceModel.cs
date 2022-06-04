using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Service.Models
{
    public class PersonServiceModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public int? BirthYear { get; set; }
        public int GenderId { get; set; }
        public bool IsActive { get; set; }
    }
}
