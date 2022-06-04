using Microsoft.EntityFrameworkCore;
using PersonManagement.Data;
using PersonManagement.Domain.POCO;
using PersonManagement.PersistanceDB.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.DataEF
{
    public class PersonRepository : IPersonRepository
    {
        protected readonly DbContext _context;
        protected readonly DbSet<Person> _dbSet;
        public PersonRepository(PersonManagementContext context)
        {
            _context = context;
            _dbSet = _context.Set<Person>();
        }
        public async Task AddAsync(Person person)
        {
            await _dbSet.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _dbSet.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetByFirstNameAsync(string firstName)
        {
            return await _dbSet.Where(x => x.FirstName == firstName).ToListAsync();
        }

        public async Task<List<Person>> GetByLastNameAsync(string lastName)
        {
            return await _dbSet.Where(x => x.LastName == lastName).ToListAsync();
        }

        public async Task<Person> GetByPersonalNumberAsync(string personalNumber)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.PersonalNumber == personalNumber);
        }
    }
}
