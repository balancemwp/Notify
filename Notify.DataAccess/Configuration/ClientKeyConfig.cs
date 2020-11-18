using Notify.DataAccess.Configuration.Base;
using Notify.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.DataAccess.Configuration
{
    public class ClientKeyConfig : BaseEntityConfig<ClientKey>
    {
        public ClientKeyConfig() : base("ClientKey")
        {
        }

        public override void Configure(EntityTypeBuilder<ClientKey> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.ClientConfigurationId).IsRequired();
            builder.Property(obj => obj.Key).IsRequired().HasMaxLength(250);
            builder.Property(obj => obj.Date).IsRequired();
        }
    }
}
