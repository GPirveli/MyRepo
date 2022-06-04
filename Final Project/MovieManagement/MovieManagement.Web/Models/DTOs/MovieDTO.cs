using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Web.Models
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string Info { get; set; }
        public bool IsActive { get; set; }
    }
}
