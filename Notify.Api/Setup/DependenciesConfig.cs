
using Emailer.Entities.Interfaces;
using Emailer.Services;
using Emailer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Emailer.Setup
{
    public static class DependenciesConfig
    {
        public static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentContextProvider, CurrentContextProvider>();

            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
