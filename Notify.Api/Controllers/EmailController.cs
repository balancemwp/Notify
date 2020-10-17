using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notify.Models;
using Notify.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Notify.Controllers
{
    [ApiController]
    [Route("emailer")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;
        private readonly ILogger<EmailController> logger;

        public EmailController(IEmailService emailService, ILogger<EmailController> logger)
        {
            this.emailService = emailService;
            this.logger = logger;
        }

        [HttpPost]
        public void Post([FromBody] ClientMessage message)
        {
            emailService.SendEmail(message);
        }

    }
}
