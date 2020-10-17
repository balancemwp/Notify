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
    public class CarrierRepository : BaseRepository<Carrier, NotifyDataContext>, ICarrierRepository
    {
        public CarrierRepository(NotifyDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(Carrier obj)
        {
            var context = GetContext();
            return await context.Carriers.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<Carrier>> Get()
        {
            var context = GetContext();
            return await context.Carriers.ToArrayAsync();
        }

        public async override Task<Carrier> Get(int id)
        {
            var context = GetContext();
            return await context.Carriers.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
