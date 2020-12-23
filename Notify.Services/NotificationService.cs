using Hangfire;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;

        public NotificationService(IEmailService emailService, IConfiguration configuration)
        {
            this.emailService = emailService;
            this.configuration = configuration;
        }

        public bool SendEmail(ClientMessage message)
        {
            var timeZone =  Convert.ToInt32(configuration["JobScheduler:TimeZone"]);
            var timePadding = Convert.ToInt32(configuration["JobScheduler:TimePaddingSeconds"]);
            var scheduledDate = DateTime.UtcNow.AddHours(- timeZone).AddSeconds(timePadding);
            BackgroundJob.Schedule<IEmailService>(job => emailService.SendEmail(message), scheduledDate);

            return true;
        }

    }
}
