using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.Models
{
    public class ClientMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
        public string Phone { get; set; }
    }
}
