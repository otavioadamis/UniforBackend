using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniforBackend.API.Authorization;
using UniforBackend.API.Exceptions;
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
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

            // Adicionando repositorios e suas abstracoes

            builder.Services.AddScoped<IItemRepo, ItemRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();

        builder.Services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

            // Configurando swagger para usar Token jwt de Auth

            builder.Services.AddSwaggerGen(
                options =>
                {
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Insert Token",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "bearer"
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Middlewares (Tratamento de excecoes e autorizacao com jwt)

        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseMiddleware<JwtMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        
        }
    }
}