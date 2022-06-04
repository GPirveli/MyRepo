using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.PersistanceDB.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {

            builder.Property(x => x.FirstName).IsRequired().IsUnicode(false).HasMaxLength(20);

            builder.Property(x => x.LastName).IsRequired().IsUnicode(false).HasMaxLength(30);

            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);

            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.Property(x => x.Role).IsUnicode(false).HasDefaultValue("RegisteredUser");
        }
    }
}
