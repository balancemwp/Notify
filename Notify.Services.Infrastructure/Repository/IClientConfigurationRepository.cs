using Notify.Entities;
using Notify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Infrastructure.Repository
{
    public interface IClientConfigurationRepository
    {
        Task<IEnumerable<ClientConfiguration>> Get();

        Task<ClientConfiguration> Get(int id);
    }
}
