using Notify.Entities;
using Notify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Repository
{
    public interface IRecipientRepository
    {
        Task<IEnumerable<Recipient>> Get();
        Task<Recipient> Get(int id);
        Task<Recipient> Edit(Recipient carrier);
    }
}
