using Notify.Entities;
using Notify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Repository
{
    public interface ICarrierRepository
    {
        Task<IEnumerable<Carrier>> Get();
        Task<Carrier> Get(int id);
        Task<Carrier> Edit(Carrier carrier);
    }
}
