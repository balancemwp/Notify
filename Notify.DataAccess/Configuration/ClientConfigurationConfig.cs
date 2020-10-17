using Notify.DataAccess.Configuration.Base;
using Notify.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.DataAccess.Configuration
{
    public class ClientConfigurationConfig: BaseEntityConfig<ClientConfiguration>
    {
        public ClientConfigurationConfig() : base("ClientConfiguration")
        {

        }
        public override void Configure(EntityTypeBuilder<ClientConfiguration> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.ApplicationName).IsRequired().HasMaxLength(50);
            builder.Property(obj => obj.UserId).IsRequired();
            builder.Property(obj => obj.CarrierId).IsRequired();
            builder.Property(obj => obj.EmailUserName).IsRequired().HasMaxLength(50);
            builder.Property(obj => obj.EmailPassword).IsRequired().HasMaxLength(25);
            builder.Property(obj => obj.Server).IsRequired().HasMaxLength(50);
            builder.Property(obj => obj.Port).IsRequired();
            builder.Property(obj => obj.RequiresAuthentication).IsRequired();
            builder.Property(obj => obj.UseSsl).IsRequired();
        }
    }
}
