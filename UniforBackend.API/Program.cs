using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using UniforBackend.API.Authorization;
using UniforBackend.API.Exceptions;
using UniforBackend.API.Extensions;
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

            var awsAccessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
            var awsSecretKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY");

            builder.Configuration["AwsConfiguration:AWSAccessKey"] = awsAccessKey;
            builder.Configuration["AwsConfiguration:AWSSecretKey"] = awsSecretKey;

            //Configurando conexao do banco de dados

            string connectionString = Environment.GetEnvironmentVariable("DatabaseSettings");

            if(connectionString == null)
            {
                var settings = builder.Configuration.GetSection("DatabaseSettings").Get<AppSettings>();
                connectionString = settings.ConnectionString;
            }

            builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString));

            // Adicionando serviços e suas abstracoes

            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IVendaService, VendaService>();
            builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IStorageService, StorageService>();
            builder.Services.AddScoped<IImagemService, ImagemService>();
            builder.Services.AddScoped<IChatService, ChatService>();

            // Adicionando repositorios e suas abstracoes

            builder.Services.AddScoped<IItemRepo, ItemRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IVendaRepo, VendaRepo>();
            builder.Services.AddScoped<ICategoriaRepo, CategoriaRepo>();
            builder.Services.AddScoped<IImagemRepo, ImagemRepo>();
            builder.Services.AddScoped<IChatRepo, ChatRepo>();
            builder.Services.AddScoped<IMensagemRepo, MensagemRepo>();

            builder.Services.AddSignalR();

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

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("prod", builder =>
                {
                    builder.WithOrigins("https://bazaruniversitario.com.br")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
                opt.AddPolicy("dev", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

	    builder.Services.AddHealthChecks();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("dev");
        }
        
        if (app.Environment.IsProduction())
        {
            app.UseCors("prod");
        }

        app.UseHttpsRedirection();

        app.ApplyMigrations();
        InitialDataHelper.InitializeDatabase(app.Services);

        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseMiddleware<JwtMiddleware>();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapHub<ChatHubService>("/chatHub");
	    app.UseHealthChecks("/healthz");

        app.Run();
        
        }
    }
}
