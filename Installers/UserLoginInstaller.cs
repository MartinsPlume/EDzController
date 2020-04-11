using System;
using AutoMapper;
using EDzController.Data;
using EDzController.Domain.Repositories;
using EDzController.Domain.Security.Hashing;
using EDzController.Domain.Security.Tokens;
using EDzController.Domain.Services;
using EDzController.Security.Hashing;
using EDzController.Security.Tokens;
using EDzController.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
namespace EDzController.Installers
{
    public class UserLoginInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenHandler, Security.Tokens.TokenHandler>();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            
            services.Configure<TokenOptions>(configuration.GetSection("TokenOptions"));
            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = signingConfigurations.Key,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddAutoMapper(GetType().Assembly);
        }
    }
}