using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurs.Core.Data;
using Kurs.Core.Infrastructure;
using Kurs.Filters;
using Kurs.Infrastructure;
using Kurs.Services.Api;
using Kurs.Services.Note;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kurs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NotesContext>(opt =>
            {
                opt
                    //.UseSqlServer(Configuration.GetConnectionString("Main"))
                    .UseInMemoryDatabase("db_inmemory");
            });
            services.AddSingleton<IMapper, Mapper>();
            services.AddSingleton<IEntityExpressionsBuilder, EntityExpressionsBuilder>();
            services.AddSingleton<IApiHelper, ApiHelper>();
            services.AddSingleton<IApiQuery, ApiQuery>();
            services.AddSingleton<ModelStateCheckActionFilterAttribute, ModelStateCheckActionFilterAttribute>();
            services.AddSingleton<ApiExceptionActionFilterAttribute, ApiExceptionActionFilterAttribute>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<INoteFileService, NoteFileService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware();
            }

            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute("spa", new
                {
                    controller = "Home",
                    action = "Index"
                });
            });
        }
    }
}