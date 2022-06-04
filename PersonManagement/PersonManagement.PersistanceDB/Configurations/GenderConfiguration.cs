using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.PersistanceDB.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GenderText).IsRequired().HasMaxLength(6);
        }
    }
}
