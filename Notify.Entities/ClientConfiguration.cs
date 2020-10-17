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
        public int CarrierId { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool RequiresAuthentication { get; set; }
        public bool UseSsl { get; set; }
        public int PhoneNumber { get; set; }

        public virtual Carrier Carrier { get; set; }

    }
}
