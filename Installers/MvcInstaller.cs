using EDzController.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EDzController.Installers
{
    public class MvcInstaller:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddRazorPages();
            services.AddCors(options => options.AddPolicy(StringResources.TitleShort, builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(@"http://localhost:3000");
            }));
            services.AddMvc();
        }
    }
}