using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Service.Models
{
    public class MovieServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Genre { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
    }
}
