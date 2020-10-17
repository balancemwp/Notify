using Emailer.Entities.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Emailer.Setup
{
    public class ContainerExtension
    {
        public static void Initialize(IServiceCollection services, string connectionString)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentContextProvider, CurrentContextProvider>();
        }
    }
}
