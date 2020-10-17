using Notify.DataAccess.Configuration.Base;
using Notify.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.DataAccess.Configuration
{
    public class CommunicationConfig: BaseEntityConfig<Communication>
    {
        public CommunicationConfig() : base("Communication")
        {
        }

        public override void Configure(EntityTypeBuilder<Communication> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Id).IsRequired();
            builder.Property(obj => obj.CommunitcationTypeId).IsRequired();
            builder.Property(obj => obj.ClientId).IsRequired();
            builder.Property(obj => obj.To).IsRequired();
            builder.Property(obj => obj.From).IsRequired();
            builder.Property(obj => obj.CC).IsRequired();
            builder.Property(obj => obj.BCC).IsRequired();
            builder.Property(obj => obj.Subject).IsRequired();
            builder.Property(obj => obj.DateSent).IsRequired();
            builder.Property(obj => obj.Body).IsRequired();

        }
    }
}
