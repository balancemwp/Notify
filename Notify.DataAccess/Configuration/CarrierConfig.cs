using Notify.DataAccess.Configuration.Base;
using Notify.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.DataAccess.Configuration
{
    public class CarrierConfig: BaseEntityConfig<Carrier>
    {
        public CarrierConfig() : base("Carriers")
        {
        }

        public override void Configure(EntityTypeBuilder<Carrier> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired().HasMaxLength(100);
            builder.Property(obj => obj.Domain).IsRequired().HasMaxLength(50);

            builder.HasMany(obj => obj.ClientConfigurations)
               .WithOne(obj => obj.Carrier)
               .HasForeignKey(b => b.CarrierId);
        }
    }
}
