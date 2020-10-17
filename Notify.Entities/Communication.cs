using Notify.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.Entities
{
    public class Communication: BaseEntity
    {
        public int ClientId { get; set; }
        public int CommunitcationTypeId { get; set; }
        public DateTime DateSent { get; set; }
        
        public string To { get; set; }
        public string From { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public virtual CommunicationType CommunicationType { get; set; }

    }
}
