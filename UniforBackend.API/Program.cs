using Microsoft.EntityFrameworkCore;
using UniforBackend.API.Helpers;
using UniforBackend.DAL.Data;

namespace UniforBackend.API
{
    public class Program
    {

        public static void Main(string[] args) { 

        var builder = WebApplication.CreateBuilder(args);

        //Configuring database connection
        var settings = builder.Configuration.GetSection("DatabaseSettings").Get<AppSettings>();
        var connectionString = settings.ConnectionString;

        builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        
        }
    }
}