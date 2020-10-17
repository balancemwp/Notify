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
    public class CommunicationRepository : BaseRepository<Communication, NotifyDataContext>, ICommunicationRepository
    {
        public CommunicationRepository(NotifyDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(Communication obj)
        {
            var context = GetContext();
            return await context.Communication.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<Communication>> Get()
        {
            var context = GetContext();
            return await context.Communication.ToArrayAsync();
        }

        public async override Task<Communication> Get(int id)
        {
            var context = GetContext();
            return await context.Communication.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
