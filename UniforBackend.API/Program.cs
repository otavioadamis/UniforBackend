using Microsoft.EntityFrameworkCore;
using UniforBackend.API.Helpers;
using UniforBackend.DAL.Data;
using UniforBackend.DAL.Repositories;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Service;

namespace UniforBackend.API
{
    public class Program
    {

        public static void Main(string[] args) { 

        var builder = WebApplication.CreateBuilder(args);

        //Configurando conexao do banco de dados
        var settings = builder.Configuration.GetSection("DatabaseSettings").Get<AppSettings>();
        var connectionString = settings.ConnectionString;

        builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString));

            // Adicionando serviços e suas abstracoes

            builder.Services.AddScoped<IItemService, ItemService>();


            // Adicionando repositorios e suas abstracoes

            builder.Services.AddScoped<IItemRepo, ItemRepo>();

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