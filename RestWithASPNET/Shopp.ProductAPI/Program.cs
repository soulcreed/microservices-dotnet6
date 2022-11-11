using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shopp.ProductAPI.Config;
using Shopp.ProductAPI.Context;
using Shopp.ProductAPI.Repository;

namespace Shopp.ProductAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder();
                builder.AddCommandLine(args);

                var config = builder.Build();
                var pathToContentRoot = Directory.GetCurrentDirectory();

                var webHostArgs = args.Where(arg => arg != "--console").ToArray();

                var host = WebHost.CreateDefaultBuilder(webHostArgs)
                         .UseConfiguration(config)
                         .UseContentRoot(pathToContentRoot)
                         .UseStartup<Startup>()
                         .Build();

                host.Run();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        //}
        //var builder = WebApplication.CreateBuilder(args);

        //    // Add services to the container.

        //    builder.Services.AddControllers();
        //    builder.Services.AddEndpointsApiExplorer();
        //    builder.Services.AddSwaggerGen(c =>
        //        {
        //            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shoop de Materiais" });
        //        });
        //    builder.Services.AddDbContext<MySQLContex>(
        //        opt => opt.UseMySql(builder.Configuration["ConnectionString:MySQLConnectionString"], new MySqlServerVersion(new Version(8, 0, 3))));
        //    IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
        //    builder.Services.AddSingleton(mapper);
        //    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //    builder.Services.AddScoped<IProductRepository, ProductRepository>();

        //    builder.Services.AddAuthentication("Bearer")
        //                    .AddJwtBearer("Bearer", options =>
        //                    {
        //                        options.Authority = "https://localhost:4435/";
        //                        options.TokenValidationParameters = new TokenValidationParameters
        //                        {
        //                            ValidateAudience = false
        //                        };
        //                    });

        //    builder.Services.AddAuthorization(options =>
        //    {
        //        options.AddPolicy("ApiScope", policy =>
        //        {
        //            policy.RequireAuthenticatedUser();
        //            policy.RequireClaim("scope", "shopps");
        //        });
        //    });

        //    builder.Services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopp.ProductAPI", Version = "v1" });
        //        c.EnableAnnotations();
        //        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //        {
        //            Description = @"Enter 'Bearer' [space] and your token!",
        //            Name = "Authorization",
        //            In = ParameterLocation.Header,
        //            Type = SecuritySchemeType.ApiKey,
        //            Scheme = "Bearer"
        //        });

        //        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        //            {
        //                new OpenApiSecurityScheme
        //                {
        //                    Reference = new OpenApiReference
        //                    {
        //                        Type = ReferenceType.SecurityScheme,
        //                        Id = "Bearer"
        //                    },
        //                    Scheme = "oauth2",
        //                    Name = "Bearer",
        //                    In= ParameterLocation.Header
        //                },
        //                new List<string> ()
        //            }
        //                    });
        //    });


        //    var app = builder.Build();

        //    // Configure the HTTP request pipeline.
        //    if (app.Environment.IsDevelopment())
        //    {
        //        app.UseSwagger();
        //        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopp.ProductAPI v1"));
        //    }

        //    app.UseHttpsRedirection();
        //    app.UseAuthentication();
        //    app.UseAuthorization();

        //    app.MapControllers();

        //    app.Run();
        }
    }
}