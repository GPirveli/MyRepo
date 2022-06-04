using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Domain.POCO;
using PersonManagement.PersistanceDB.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.PersistanceDB.Seed
{
    public static class GenderSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using var scope = serviceProvider.CreateScope();
            var database = scope.ServiceProvider.GetRequiredService<PersonManagementContext>();

            Migrate(database);
            SeedEverything(database);
        }

        private static void SeedEverything(PersonManagementContext context)
        {
            var seeded = false;

            SeedGenders(context, ref seeded);

            if (seeded)
                context.SaveChanges();
        }

        private static void Migrate(PersonManagementContext context)
        {
            context.Database.Migrate();
        }

        private static void SeedGenders(PersonManagementContext context, ref bool seeded)
        {
            var genders = new List<Gender>()
            {
                new Gender()
                {
                    GenderText = "Male"
                },
                   new Gender()
                {
                    GenderText = "Female"
                }
            };

            foreach (var gender in genders)
            {
                if (context.Genders.AnyAsync(x => x.GenderText == gender.GenderText).Result) continue;

                context.Genders.Add(gender);
                seeded = true;
            }
        }
    }
}
