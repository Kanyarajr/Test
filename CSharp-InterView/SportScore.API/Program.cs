using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using SportScore.API.Controllers.Sports.Database;
using SportScore.API.Controllers.Sports.Database.Repositories;
using SportScore.API.Controllers.Sports.Service;

namespace SportScore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MatchResultContext>(options =>
            options.UseSqlServer
            (builder.Configuration.GetConnectionString("MatchDb")));


            builder.Services.AddScoped<IMatchResultService, MatchResultService>();
            builder.Services.AddScoped<IMatchResultRepository, MatchResultRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sports Score API V1");
                    c.RoutePrefix = string.Empty; // Serve the Swagger UI at the root URL
                });
            }

            // app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}