using Notify.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.Entities
{
    public class ClientConfiguration: BaseEntity
    {
        public int UserId { get; set; }
        public string ApplicationName { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool RequiresAuthentication { get; set; }
        public bool UseSsl { get; set; }

        public virtual ICollection<Recipient> Recipients { get; set; }

        public virtual ICollection<ClientKey> ClientKeys { get; set; }

    }
}
