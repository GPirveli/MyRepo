using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.PersistanceDB.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PersonalNumber).IsRequired().HasMaxLength(11).IsFixedLength();
            builder.Property(x => x.BirthYear).IsRequired(false);
            builder.Property(x => x.GenderId).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.HasOne(x => x.Gender).WithMany(x => x.People);
        }
    }
}
