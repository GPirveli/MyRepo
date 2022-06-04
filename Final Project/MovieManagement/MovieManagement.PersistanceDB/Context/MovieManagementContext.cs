using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Domain;
using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.PersistanceDB.Context
{
    public class MovieManagementContext : IdentityDbContext<Account>
    {
        public MovieManagementContext(DbContextOptions<MovieManagementContext> options) : base(options)
        {
          
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SoldTicket> SoldTickets { get; set; }
        public DbSet<BookedTicket> BookedTickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieManagementContext).Assembly);
        }
    }
}
