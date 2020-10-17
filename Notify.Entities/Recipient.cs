using Notify.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.Entities
{
    public class Recipient: BaseEntity
    {
        public int ClientConfigurationId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool SendEmail { get; set; }
        public bool SendText { get; set; }
        public int CarrierId { get; set; }

        public virtual Carrier Carrier { get; set; }
        public virtual ClientConfiguration ClientConfiguration { get; set; }
        
    }
}
