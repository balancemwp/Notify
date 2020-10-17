using Notify.Entities.Base;
using System;
using System.Collections.Generic;

namespace Notify.Entities
{
    public class CommunicationType : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Communication> Communications { get; set; }
    }
}
