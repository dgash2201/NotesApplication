using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Application;
using NotesApplication.Application.Common.Settings;
using NotesApplication.Infrastructure;
using System.Reflection;

namespace NotesApplication.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .Build();

            configuration.GetSection("ApplicationSettings").Bind(Config.ApplicationSettings);

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder.Services
            .AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1);
                o.ReportApiVersions = true;
            })
            .AddApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            builder.Services.AddDbContext<NotesDbContext>(o =>
            {
                o.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddApplication();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                var descriptions = app.DescribeApiVersions();

                // build a swagger endpoint for each discovered API version
                foreach (var description in descriptions)
                {
                    var url = $"/swagger/{description.GroupName}/swagger.json";
                    var name = description.GroupName.ToUpperInvariant();
                    o.SwaggerEndpoint(url, name);
                }                
            });

            app.UseExceptionHandler(app => app.Run(async context =>
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Ошибка на стороне сервера");
            }));
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
