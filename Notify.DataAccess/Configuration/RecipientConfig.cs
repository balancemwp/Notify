using Notify.DataAccess.Configuration.Base;
using Notify.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.DataAccess.Configuration
{
    public class RecipientConfig: BaseEntityConfig<Recipient>
    {
        public RecipientConfig() : base("Recipient")
        {
        }

        public override void Configure(EntityTypeBuilder<Recipient> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Email).HasMaxLength(50);
            builder.Property(obj => obj.PhoneNumber);
            builder.Property(obj => obj.SendEmail);
            builder.Property(obj => obj.SendText);
            builder.Property(obj => obj.CarrierId);
            builder.Property(obj => obj.ClientConfigurationId).IsRequired();
        }
    }
}
