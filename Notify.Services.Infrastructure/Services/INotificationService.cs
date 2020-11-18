using Notify.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.Infrastructure.Services
{
    public interface INotificationService
    {
        bool SendEmail(ClientMessage message);
    }
}
