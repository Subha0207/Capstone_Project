
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PizzaApp.Contexts;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Repositories;
using PizzaApp.Services;
using System.Text;
using System.Text.Json.Serialization;

namespace PizzaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaApp API", Version = "v1" });

                // Add security definition for JWT Bearer
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:5500")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });


            builder
               .Services.AddControllers(options =>
               {
                   options.Filters.Add(new AuthorizeFilter());
               })
               .ConfigureApiBehaviorOptions(options =>
                   options.SuppressModelStateInvalidFilter = true
               )
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
               });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                    };
                });


            #region Context
            builder.Services.AddDbContext<PizzaAppContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );
            #endregion


            #region Repositories
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<PizzaRepository>();

            builder.Services.AddScoped<BeverageRepository>();
            builder.Services.AddScoped<CrustRepository>();
            builder.Services.AddScoped<SizeRepository>();
            builder.Services.AddScoped<ToppingRepository>();
            builder.Services.AddScoped<CartRepository>();
            builder.Services.AddScoped<CartItemRepository>();
            #endregion
            #region Services

            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped(typeof(IPizzaService), typeof(PizzaService));
            builder.Services.AddScoped<IBeverageService, BeverageService>();
            builder.Services.AddScoped<ICrustService, CrustService>();
            builder.Services.AddScoped<ISizeService, SizeService>();
            builder.Services.AddScoped<IToppingService, ToppingService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICartItemService, CartItemService>();
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("AllowSpecificOrigin");

            app.MapControllers();

            app.Run();
        }
    }
}
