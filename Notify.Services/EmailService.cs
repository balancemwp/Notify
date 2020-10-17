using Notify.Models;
using Notify.Services.Interfaces;
using FluentEmail.Core;
using FluentEmail.MailKitSmtp;
using FluentEmail.Razor;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.IO;
using System.Threading.Tasks;
using Notify.Infrastructure.Repository;
using System.Linq;
using FluentEmail.Core.Models;
using System.Collections.Generic;
using Notify.Entities;

namespace Notify.Services
{
    public class EmailService : IEmailService
    {
        private IClientConfigurationRepository clientConfigurationRepository;
        private IHostingEnvironment hostingEnvironment;
        private IConfiguration config;

        public EmailService(IClientConfigurationRepository clientConfigurationRepository,
                            IHostingEnvironment hostingEnvironment, IConfiguration config)
        {
            this.clientConfigurationRepository = clientConfigurationRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.config = config;
        }

        public bool SendEmail(ClientMessage clientMessage)
        {
            var clientConfig = this.clientConfigurationRepository.Get(clientMessage.Id).Result;

            var recipientList = clientConfig.Recipients.ToList();
            var textTo = new List<Address>();
            var emailTo = new List<Address>();

            foreach (var item in recipientList)
            {
                if (item.SendEmail)
                {
                    var address = new Address() { EmailAddress = item.Email, Name = "Martin" };
                    emailTo.Add(address);
                }

                if (item.SendText)
                {
                    var address = new Address() { EmailAddress = $"{item.PhoneNumber}@{item.Carrier.Domain}" };
                    textTo.Add(address);
                }
            }

            Email.DefaultRenderer = new RazorRenderer();

            var templatePath = config["Templates:Email"];
            var welcomeEmail = new ContactRequestEmail() { Name = clientMessage.Name, Phone = clientMessage.Phone, 
                                                           Email = clientMessage.From, Message = clientMessage.Message  };
            var currentDirectory = Directory.GetCurrentDirectory();

            var subject = $"Contact Request From {clientMessage.Name}";

            var email = Email
                            .From(clientConfig.EmailUserName)
                            .To(emailTo)
                            .Subject(subject)
                            .UsingTemplateFromFile($"{currentDirectory}/{templatePath}/ContactRequest.cshtml", welcomeEmail);

            var ret = sendEmail(email, clientConfig);

            var sms = Email
                           .From(clientConfig.EmailUserName)
                           .To(textTo)
                           .Subject(subject)
                           .UsingTemplateFromFile($"{currentDirectory}/{templatePath}/ContactRequestText.cshtml", welcomeEmail);

            var smsRet = sendEmail(sms, clientConfig);

            return true;
        }

        private async Task<SendResponse> sendEmail(IFluentEmail email, ClientConfiguration clientConfig)
        {
            var option = new SmtpClientOptions();

            option.Server = clientConfig.Server;
            option.User = clientConfig.EmailUserName;
            option.Password = clientConfig.EmailPassword;
            option.Port = clientConfig.Port;
            option.RequiresAuthentication = clientConfig.RequiresAuthentication;
            option.UseSsl = clientConfig.UseSsl;

            email.Sender = new MailKitSender(option);
            var status = await email.SendAsync();
            return status;
        }

    }
}
