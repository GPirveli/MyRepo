using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.PersistanceDB.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Info).IsRequired().HasMaxLength(300);

            builder.Property(x => x.Url).IsRequired();

            builder.Property(x => x.Genre).IsRequired().HasMaxLength(20);

            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
