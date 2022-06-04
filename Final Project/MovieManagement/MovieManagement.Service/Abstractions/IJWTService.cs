using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Service.Abstractions
{
    public interface IJWTService
    {
        string GenerateSecurityToken(string userName, string id);
    }
}
