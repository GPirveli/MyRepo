using PersonManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Data
{
    public interface IPersonRepository
    {
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task<List<Person>> GetByFirstNameAsync(string firstName);
        Task<List<Person>> GetByLastNameAsync(string lastName);
        Task<Person> GetByPersonalNumberAsync(string personalNumber);
    }
}
