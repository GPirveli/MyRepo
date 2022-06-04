using Mapster;
using PersonManagement.Data;
using PersonManagement.Domain.POCO;
using PersonManagement.Service.Abstractions;
using PersonManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Service.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repo;
        public PersonService(IPersonRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(PersonServiceModel person)
        {
            var personToAdd = person.Adapt<Person>();
            await _repo.AddAsync(personToAdd);
        }

        public async Task<List<PersonServiceModel>> GetByFirstNameAsync(string firstName)
        {
            var people = await _repo.GetByFirstNameAsync(firstName);
            return people.Adapt<List<PersonServiceModel>>();
        }

        public async Task<List<PersonServiceModel>> GetByLastNameAsync(string lastName)
        {
            var people = await _repo.GetByLastNameAsync(lastName);
            return people.Adapt<List<PersonServiceModel>>();
        }

        public async Task<PersonServiceModel> GetByPersonalNumberAsync(string personalNumber)
        {
            var people = await _repo.GetByPersonalNumberAsync(personalNumber);
            return people.Adapt<PersonServiceModel>();
        }

        public async Task UpdateAsync(PersonServiceModel person)
        {
            var personToUpdate = person.Adapt<Person>();
            await _repo.UpdateAsync(personToUpdate);
        }
    }
}
