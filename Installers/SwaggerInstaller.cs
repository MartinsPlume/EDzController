using System;
using System.IO;
using System.Reflection;
using System.Resources;
using EDzController.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EDzController.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        private readonly ResourceManager _resourceManager = new ResourceManager(typeof(StringResources));

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = _resourceManager.GetString("TitleLong"),
                    Version = "v1",
                    Description = _resourceManager.GetString("DescriptionLong"),
                    Contact = new OpenApiContact
                    {
                        Name = "Teacher",
                        Email = "teacher@teacher.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT"
                    }
                });
                cfg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JSON Web Token to access resources. Example: Bearer {token}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        new[] {string.Empty}
                    }
                });
            });
        }
    }
}