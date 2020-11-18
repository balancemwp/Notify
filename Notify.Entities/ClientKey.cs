using Notify.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.Entities
{
    public class ClientKey : BaseEntity
    {
        public string Key { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }

        public int ClientConfigurationId  { get; set; }
        public virtual ClientConfiguration ClientConfiguration { get; set;}
    }
}
