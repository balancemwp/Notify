using Notify.DataAccess.Configuration.Base;
using Notify.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.DataAccess.Configuration
{
    public class UserConfig: BaseEntityConfig<User>
    {
        public UserConfig() : base("User")
        {
        }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(obj => obj.LastName).IsRequired().HasMaxLength(25);
            builder.Property(obj => obj.Email).IsRequired().HasMaxLength(50);
        }
    }
}
