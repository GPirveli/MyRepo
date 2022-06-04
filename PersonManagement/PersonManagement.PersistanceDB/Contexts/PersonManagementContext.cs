using Microsoft.EntityFrameworkCore;
using PersonManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.PersistanceDB.Contexts
{
    public class PersonManagementContext : DbContext
    {
        public PersonManagementContext(DbContextOptions<PersonManagementContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Gender> Genders { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonManagementContext).Assembly);
        }
    }
}
