using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.Domain;
using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.PersistanceDB.Configurations
{
    class BookedTicketConfiguration : IEntityTypeConfiguration<BookedTicket>
    {
        public void Configure(EntityTypeBuilder<BookedTicket> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SessionId).IsRequired();

            builder.Property(x => x.AccountId).IsRequired();

            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.HasOne(x => x.Account).WithMany(x => x.BookedTickets);
            builder.HasOne(x => x.Session).WithMany(x => x.BookedTickets);
        }
    }
}
