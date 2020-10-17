using Notify.DataAccess.Configuration;
using Notify.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Notify.DataAccess.Repository
{
    public class NotifyDataContext : DbContext
    {
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<ClientConfiguration> ClientConfiguration { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CarrierConfig());
            modelBuilder.ApplyConfiguration(new ClientConfigurationConfig());
            modelBuilder.ApplyConfiguration(new CommunicationConfig());
            modelBuilder.ApplyConfiguration(new CommunicationTypeConfig());

            modelBuilder.HasDefaultSchema("notify");
        }
    }
}
