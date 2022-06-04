using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Domain.POCO
{
    public class Gender
    {
        public int Id { get; set; }
        public string GenderText { get; set; }
        public List<Person> People { get; set; }
    }
}
