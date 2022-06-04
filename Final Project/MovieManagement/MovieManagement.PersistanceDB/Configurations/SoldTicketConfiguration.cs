using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.PersistanceDB.Configurations
{
    public class SoldTicketConfiguration : IEntityTypeConfiguration<SoldTicket>
    {
        public void Configure(EntityTypeBuilder<SoldTicket> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SessionId).IsRequired();

            builder.Property(x => x.AccountId).IsRequired();

            builder.HasOne(x => x.Account).WithMany(x => x.SoldTickets);
            builder.HasOne(x => x.Session).WithMany(x => x.SoldTickets);
        }
    }
}