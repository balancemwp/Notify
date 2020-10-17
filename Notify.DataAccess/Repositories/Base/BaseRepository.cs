using Microsoft.EntityFrameworkCore;
using Notify.DataAccess.EFCore;
using Notify.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notify.DataAccess.Repositories.Base
{
    public abstract class BaseRepository<TType, TContext>
        where TType : BaseEntity, new()
        where TContext : NotifyDataContext
    {
        protected TContext dbContext;

        protected BaseRepository(TContext context)
        {
            this.dbContext = context;
        }

        protected TContext GetContext()
        {
            return dbContext;
        }

        public abstract Task<TType> Get(int id);
        public abstract Task<bool> Exists(TType obj);

        public virtual async Task<TType> Edit(TType obj)
        {
            var objectExists = await Exists(obj);
            var context = GetContext();

            context.Entry(obj).State = objectExists ? EntityState.Modified : EntityState.Added;
            await context.SaveChangesAsync();
            return obj;

        }

        public virtual async Task Delete(int id)
        {
            var context = GetContext();

            var itemToDelete = new TType { Id = id };
            context.Entry(itemToDelete).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
