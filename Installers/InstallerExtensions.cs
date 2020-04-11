using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EDzController.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssemblies(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(IInstaller)
                .Assembly
                .ExportedTypes
                .Where(x => typeof(IInstaller)
                    .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();
            
            installers
                .ForEach(installer => installer
                    .InstallServices(services, configuration));
        }
    }
}