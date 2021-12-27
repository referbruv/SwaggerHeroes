using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SwaggerHeroes.Core.Data.Services;
using System;
using System.Linq;

namespace SwaggerHeroes.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var db = services.GetRequiredService<IDataService>();

                if (db.Heroes.All().Count() == 0)
                {
                    db.Heroes.Create(new Core.Data.Entities.Hero
                    {
                        Name = "Goku",
                        Powers = "Flying,Jumping,Leaping",
                        HasCape = false,
                        IsAlive = true,
                        Category = Core.Enums.Category.Anime
                    });
                    db.Heroes.Create(new Core.Data.Entities.Hero
                    {
                        Name = "Saiyaman",
                        Powers = "Flying,Jumping,Leaping",
                        HasCape = true,
                        IsAlive = true,
                        Category = Core.Enums.Category.Anime
                    });
                    db.SaveChanges();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
