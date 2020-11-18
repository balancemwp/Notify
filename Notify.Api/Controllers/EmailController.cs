using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notify.Models;
using Notify.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notify.Infrastructure.Services;

namespace Notify.Controllers
{
    [ApiController]
    [Route("emailer")]
    public class EmailController : ControllerBase
    {
        private readonly INotificationService notificationService;
        private readonly ILogger<EmailController> logger;

        public EmailController(INotificationService notificationService, ILogger<EmailController> logger)
        {
            this.notificationService = notificationService;
            this.logger = logger;
        }

        [HttpPost]
        public void Post([FromBody] ClientMessage message)
        {
            notificationService.SendEmail(message);
        }

    }
}
