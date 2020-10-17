using Notify.Entities;
using Notify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Repository
{
    public interface ICommunicationRepository
    {
        Task<IEnumerable<Communication>> Get();

        Task<Communication> Get(int id);
    }
}
