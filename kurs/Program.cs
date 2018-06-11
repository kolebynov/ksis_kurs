using System;
using Kurs.Core.Data;
using Kurs.Core.Domain;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Kurs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                NotesContext context = scope.ServiceProvider.GetRequiredService<NotesContext>();
                context.Users.Add(new User
                {
                    Id = new Guid("{3A506041-A5D6-48BC-A8FA-04BF8306A53A}")
                });
                context.Notes.Add(new Note
                {
                    Id = new Guid("{E6818C3A-8150-4ED1-83EC-86BA8576750A}"),
                    Description = "123",
                    UserId = new Guid("{3A506041-A5D6-48BC-A8FA-04BF8306A53A}")
                });
                context.NoteCategories.Add(new NoteCategory
                {
                    Id = new Guid("{D6355772-F33D-4442-AF04-E1A184736730}"),
                    Name = "Без категории"
                });
                context.SaveChanges();
            }


            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
