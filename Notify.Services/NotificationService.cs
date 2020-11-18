using Hangfire;
using Notify.Infrastructure.Services;
using Notify.Models;
using Notify.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.Services
{
    public class NotificationService: INotificationService
    {
        private readonly IEmailService emailService;

        public NotificationService(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public bool SendEmail(ClientMessage message)
        {
            BackgroundJob.Enqueue<IEmailService>(job => emailService.SendEmail(message));

            return true;
        }

    }
}
