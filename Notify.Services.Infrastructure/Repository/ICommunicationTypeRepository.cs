using Notify.Entities;
using Notify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Repository
{
    public interface ICommunicationTypeRepository
    {
        Task<IEnumerable<CommunicationType>> Get();

        Task<CommunicationType> Get(int id);
    }
}
