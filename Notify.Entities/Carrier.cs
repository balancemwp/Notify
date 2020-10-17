using Notify.Entities.Base;
using System;
using System.Collections.Generic;

namespace Notify.Entities
{
    public class Carrier: BaseEntity
    {
        public string Name { get; set; }
        public string Domain { get; set; }

        public virtual ICollection<ClientConfiguration> ClientConfigurations { get; set; }
    }
}
