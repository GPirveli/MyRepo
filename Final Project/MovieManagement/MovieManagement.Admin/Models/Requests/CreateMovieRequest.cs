using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Admin.Models.Requests
{
    public class CreateMovieRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Info { get; set; }
    }
}
