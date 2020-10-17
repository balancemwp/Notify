using Microsoft.EntityFrameworkCore;
using Notify.DataAccess.EFCore;
using Notify.DataAccess.Repositories.Base;
using Notify.Entities;
using Notify.Infrastructure.Repository;
using Notify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.DataAccess.Repositories
{
    public class RecipientRepository : BaseRepository<Recipient, NotifyDataContext>, IRecipientRepository
    {

        public RecipientRepository(NotifyDataContext context): base(context)
        {
        }

        public override async Task<bool> Exists(Recipient obj)
        {
            var context = GetContext();
            return await context.Recipient.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<Recipient>> Get()
        {
            var context = GetContext();
            return await context.Recipient.ToArrayAsync();
        }

        public override async Task<Recipient> Get(int id)
        {
            var context = GetContext();
            return await context.Recipient.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
