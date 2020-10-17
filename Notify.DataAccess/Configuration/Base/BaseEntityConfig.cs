﻿using Notify.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.DataAccess.Configuration.Base
{
    public abstract class BaseEntityConfig<TType> : IEntityTypeConfiguration<TType>
       where TType : BaseEntity
    {
        protected string TableName { get; set; }

        public BaseEntityConfig(string tableName)
        {
            TableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TType> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(obj => obj.Id);
        }
    }
}
