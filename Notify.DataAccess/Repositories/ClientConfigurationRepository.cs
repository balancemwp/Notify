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
    public class ClientConfigurationRepository : BaseRepository<ClientConfiguration, NotifyDataContext>, IClientConfigurationRepository
    {
        public ClientConfigurationRepository(NotifyDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(ClientConfiguration obj)
        {
            var context = GetContext();
            return await context.ClientConfiguration.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<ClientConfiguration>> Get()
        {
            var context = GetContext();
            return await context.ClientConfiguration.ToArrayAsync();
        }

        public async override Task<ClientConfiguration> Get(int id)
        {
            var context = GetContext();
            return await context.ClientConfiguration.Where(x => x.Id == id)
                .Include(c => c.Recipients).ThenInclude(r => r.Carrier)
                .AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
