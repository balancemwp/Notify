using Notify.DataAccess.Configuration.Base;
using Notify.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.DataAccess.Configuration
{
    public class CommunicationTypeConfig : BaseEntityConfig<CommunicationType>
    {
        public CommunicationTypeConfig() : base("CommunicationType")
        {
        }

        public override void Configure(EntityTypeBuilder<CommunicationType> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired().HasMaxLength(25);

            builder.HasMany(obj => obj.Communications)
               .WithOne(obj => obj.CommunicationType)
               .HasForeignKey(b => b.CommunitcationTypeId);
        }
    }
}
