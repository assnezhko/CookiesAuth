using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System.Collections.Generic;
using CookiesAuth.Models.ORM;
using Services;

namespace CookiesAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var factory = services.GetRequiredService<IRepositoryContextFactory>();

                using (var context = factory.CreateDbContext(config.GetConnectionString("DefaultConnection")))
                {
                    var securityService = services.GetRequiredService<ISecurityService>();

                    var UsersInitialize = new List<User>();

                    var admin = new User()
                    {
                        Email = "admin@gmail.com",
                        Password = securityService.getMd5Hash("admin123"),
                        IsAdmin = true
                    };

                    UsersInitialize.Add(admin);

                    DbInitializer.Initialize(context, UsersInitialize).Wait();
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
