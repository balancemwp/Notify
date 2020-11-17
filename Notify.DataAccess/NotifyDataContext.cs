using Notify.DataAccess.Configuration;
using Notify.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Notify.DataAccess.EFCore
{
    public class NotifyDataContext : DbContext
    {
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<ClientConfiguration> ClientConfiguration { get; set; }

        public DbSet<ClientKey> ClientKey { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Recipient> Recipient { get; set; }
        public DbSet<Communication> Communication { get; set; }
        public DbSet<CommunicationType> CommunicationType { get; set; }

        public NotifyDataContext(DbContextOptions<NotifyDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CarrierConfig());
            modelBuilder.ApplyConfiguration(new ClientConfigurationConfig());
            modelBuilder.ApplyConfiguration(new ClientKeyConfig());
            modelBuilder.ApplyConfiguration(new CommunicationConfig());
            modelBuilder.ApplyConfiguration(new CommunicationTypeConfig());
            modelBuilder.ApplyConfiguration(new RecipientConfig());

            modelBuilder.HasDefaultSchema("notify");
        }
    }
}
