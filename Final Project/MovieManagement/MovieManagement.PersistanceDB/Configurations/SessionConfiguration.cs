using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.PersistanceDB.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {


            builder.HasKey(x => x.Id);

            builder.Property(x => x.MovieId).IsRequired();

            builder.Property(x => x.StartTime).IsRequired().HasColumnType("datetime");

            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.HasOne(x => x.Movie).WithMany(x => x.Sessions);

        }
    }
}
