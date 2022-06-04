using PersonManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Service.Abstractions
{
    public interface IActivityService
    {
        Task<string> GetAllAsync();
    }
}
