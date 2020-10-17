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
    public class CommunicationTypeRepository : BaseRepository<CommunicationType, NotifyDataContext>, ICommunicationTypeRepository
    {
        public CommunicationTypeRepository(NotifyDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(CommunicationType obj)
        {
            var context = GetContext();
            return await context.CommunicationType.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<CommunicationType>> Get()
        {
            var context = GetContext();
            return await context.CommunicationType.ToArrayAsync();
        }

        public async override Task<CommunicationType> Get(int id)
        {
            var context = GetContext();
            return await context.CommunicationType.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
