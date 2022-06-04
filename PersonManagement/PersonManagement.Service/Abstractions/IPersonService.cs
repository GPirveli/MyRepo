using PersonManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Service.Abstractions
{
    public interface IPersonService
    {
        Task AddAsync(PersonServiceModel person);
        Task UpdateAsync(PersonServiceModel person);
        Task<List<PersonServiceModel>> GetByFirstNameAsync(string firstName);
        Task<List<PersonServiceModel>> GetByLastNameAsync(string lastName);
        Task<PersonServiceModel> GetByPersonalNumberAsync(string personalNumber);
    }
}
