using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProvaConceitoTimeIAGRO.Interface;
using ProvaConceitoTimeIAGRO.Model;
using ProvaConceitoTimeIAGRO.Servico;
using System;
using System.IO;
using System.Reflection;
using Swashbuckle.AspNetCore.Annotations;
using ProvaConceitoTimeIAGRO.Repository;

namespace ProvaConceitoTimeIAGRO
{
    /// <summary>
    /// Class Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor Startup
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // NOTE: Codigo comentado devido que iria colocar json InMemory
        // mas devido que nem todo conteudo do json é tipo primitivo não 
        // houve tempo habil para procurar outra solução
        // Uma que poderia seria o automapper, mas não tive como realizar o teste

        /// <summary>
        /// Configure Services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // services.AddDbContext<TodoContext>(options => options.UseInMemoryDatabase(databaseName: "BookDb"));

            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<IGenericService<Book>, BookService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProvaConceitoTimeIAGRO", Version = "v1" });
               
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.EnableAnnotations();
            });
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IWebHostEnvironment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProvaConceitoTimeIAGRO v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}