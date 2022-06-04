using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Service.Models.JWT
{
    public class JWTConfiguration
    {
        public string Secret { get; set; }
        public int ExpirationInMinutes { get; set; }
    }
}
