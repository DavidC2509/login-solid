using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Template.Domain.Interface;
using Template.Services.Services;

namespace Template.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //var serviceClientSettings = new RabbitConfigurationProvider().GetConfiguration();

            //services.AddSingleton<IRabbitConfigurationProvider, RabbitConfigurationProvider>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Todos los repositorys
            services.AddScoped<IEncryptPassword, EncryptPasswordSha256>();

            services.AddScoped<ILogServices, LogsSaveDatabase>();

            return services;
        }

    }
}
