using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EDzController.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(x => 
                { x.SwaggerDoc("v1", new OpenApiInfo {Title = "My API", Version = "v1"}); });
        }
    }
}
