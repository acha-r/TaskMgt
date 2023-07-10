using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskMgt.Context;
using TaskMgt.Extensions;
using TaskMgt.Models;

namespace TaskMgt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterServices();
            builder.Services.ConfigureCors();

            builder.Services.AddDBConnection(builder.Configuration);

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });/*
                 .AddJwtBearer(jwt =>
                 {

                     string jwtConfig = builder.Configuration.GetSection("JwtConfig:Key").Value;
                     string issuer = builder.Configuration.GetSection("JwtConfig:Issuer").Value;
                     string audience = builder.Configuration.GetSection("JwtConfig:Audience").Value;
                     var key = Encoding.ASCII.GetBytes(jwtConfig);

                     jwt.SaveToken = true;
                     jwt.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(key),
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         RequireExpirationTime = true,
                         ValidIssuer = issuer,
                         ValidAudience = audience,
                         *//*ClockSkew = TimeSpan.Zero*//*
                     };
                 });
*/
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