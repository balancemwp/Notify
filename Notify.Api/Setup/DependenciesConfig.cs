
using Notify.Services;
using Notify.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Notify.Setup;
using Notify.DataAccess.EFCore;
using Notify.Infrastructure.Repository;
using Notify.DataAccess.Repositories;

namespace Notify.Setup
{
    public static class DependenciesConfig
    {
        public static void ConfigureDependencies(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NotifyDataContext>(options => options.UseSqlServer(connectionString));

            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentContextProvider, CurrentContextProvider>();

            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<ICarrierRepository, CarrierRepository>();
            services.AddScoped<ICommunicationRepository, CommunicationRepository>();
            services.AddScoped<ICommunicationTypeRepository, CommunicationTypeRepository>();
            services.AddScoped<IClientConfigurationRepository, ClientConfigurationRepository>();
            services.AddScoped<IRecipientRepository, RecipientRepository>();
        }
    }
}
