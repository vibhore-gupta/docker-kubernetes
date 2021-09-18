using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlaformService.Models;
using PlatformService.Data;

namespace PlatforService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                 SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext appDbContext)
        {
            if(!appDbContext.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data");
                 appDbContext.Platforms.AddRange(
                     new Platform () { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"},
                     new Platform () { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free"},
                     new Platform () { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free"}
                     );
                
                appDbContext.SaveChanges();
            } 
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}