using Microsoft.EntityFrameworkCore;
using System;

namespace Emailer.Repository
{
    public class EmailerDataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("emailer");
        }
    }
}
