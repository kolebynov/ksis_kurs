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

                context.NoteCategories.Add(new NoteCategory
                {
                    Id = new Guid("{D6355772-F33D-4442-AF04-E1A184736730}"),
                    Name = "Без категории"
                });
                context.NoteCategories.Add(new NoteCategory
                {
                    Id = new Guid("{C4DF6812-A361-4C95-A110-D00393308050}"),
                    Name = "Категория 1"
                });

                context.Notes.Add(new Note
                {
                    Id = new Guid("{E6818C3A-8150-4ED1-83EC-86BA8576750A}"),
                    Name = "123",
                    Description = "123",
                    CategoryId = new Guid("{D6355772-F33D-4442-AF04-E1A184736730}")
                });
                context.Notes.Add(new Note
                {
                    Id = new Guid("{7982D3F7-0270-4A63-8FC8-66BEA83E1890}"),
                    Name = "1234",
                    Description = "1234",
                    CategoryId = new Guid("{C4DF6812-A361-4C95-A110-D00393308050}")
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
