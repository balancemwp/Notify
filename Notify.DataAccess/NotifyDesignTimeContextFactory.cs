using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Notify.DataAccess.EFCore
{
    class NotifyDesignTimeContextFactory : IDesignTimeDbContextFactory<NotifyDataContext>
    {
        public NotifyDesignTimeContextFactory() { }
        public NotifyDataContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Notify.Api"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("NotifyDatabase");

            var builder = new DbContextOptionsBuilder<NotifyDataContext>();
            builder.UseSqlServer(connectionString);

            return new NotifyDataContext(builder.Options);
        }
    }
}
