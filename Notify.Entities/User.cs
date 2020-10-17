using Notify.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.Entities
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
