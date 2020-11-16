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
using Microsoft.Extensions.Logging;
using System.Text;
using Notify.Utitlity;

namespace Notify.Services
{
    public class EmailService : IEmailService
    {
        private IClientConfigurationRepository clientConfigurationRepository;
        private IConfiguration config;
        private ILogger<EmailService> logger;

        public EmailService(IClientConfigurationRepository clientConfigurationRepository,
                            IConfiguration config, ILogger<EmailService> logger)
        {
            this.clientConfigurationRepository = clientConfigurationRepository;
            this.config = config;
            this.logger = logger;
        }

        public bool SendEmail(ClientMessage clientMessage)
        {
            var clientConfig = clientConfigurationRepository.Get(clientMessage.Id).Result;

            decrypt(ref clientConfig);

            var recipientList = clientConfig.Recipients.ToList();
            var emailTo = new List<Address>();
            var textTo = new List<Address>();

            setRecipientList(recipientList, ref emailTo, ref textTo);

            var templatePath = config["Templates:Email"];

            var currentDirectory = Directory.GetCurrentDirectory();

            var emailSubject = $"Contact Request From {clientMessage.Name}";

            var email = createEmail(clientConfig.EmailUserName, emailTo, emailSubject, $"{currentDirectory}/{templatePath}/ContactRequest.cshtml",
                               clientMessage);

            var emailSendResponse = sendEmail(email, clientConfig);

            handleResult(emailSendResponse, "email");

            var textSubject = "Contact Request";
            var textEmail = createEmail(clientConfig.EmailUserName, textTo, textSubject, $"{currentDirectory}/{templatePath}/ContactRequestText.cshtml",
                                   clientMessage);

            var smsSendResponse = sendEmail(textEmail, clientConfig);
            
            handleResult(smsSendResponse, "text");

            return true;
        }

        private void setRecipientList(List<Recipient> recipients, ref List<Address> emailTo, ref List<Address> textTo)
        {
            foreach (var item in recipients)
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
        }

        private IFluentEmail createEmail(string from, List<Address> to, string subject, string template, ClientMessage clientMessage)
        {
            Email.DefaultRenderer = new RazorRenderer();

            var email = Email
                           .From(from)
                           .To(to)
                           .Subject(subject)
                           .UsingTemplateFromFile(template, clientMessage);

            return email;
        }

        private async Task<SendResponse> sendEmail(IFluentEmail email, ClientConfiguration clientConfig)
        {
            //var token = config["SmtpOptions:Signature"];
            //var key256 = new byte[32];
            //var nonSecretOrg = Encoding.UTF8.GetBytes(token);

            //for (int i = 0; i < 32; i++)
            //    key256[i] = Convert.ToByte(i % 256);

            //var server = AESGCM.SimpleDecrypt(clientConfig.Server, key256, nonSecretOrg.Length);
            //var userName = AESGCM.SimpleDecrypt(clientConfig.EmailUserName, key256, nonSecretOrg.Length);
            //var password = AESGCM.SimpleDecrypt(clientConfig.EmailPassword, key256, nonSecretOrg.Length);

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
        private void handleResult(Task<SendResponse> response, string type) 
        {
            var emailResult = response.Result;

            if (emailResult.Successful)
            {
                logger.LogInformation($"{type} {emailResult.MessageId} sent successfully");
            }
            else
            {
                var errors = new StringBuilder();

                foreach (var item in emailResult.ErrorMessages)
                {
                    errors.Append(item).Append("|");
                }

                var errorMessage = errors.ToString();
                logger.LogError($"email delivery failed. {errorMessage}");
            }
        }

        private void decrypt(ref ClientConfiguration configuration)
        {
            var token = config["SmtpOptions:Signature"];
            var option = new SmtpClientOptions();
            var key256 = new byte[32];
            var nonSecretOrg = Encoding.UTF8.GetBytes(token);

            for (int i = 0; i < 32; i++)
                key256[i] = Convert.ToByte(i % 256);

            configuration.Server = AESGCM.SimpleDecrypt(configuration.Server, key256, nonSecretOrg.Length);
            configuration.EmailUserName = AESGCM.SimpleDecrypt(configuration.EmailUserName, key256, nonSecretOrg.Length);
            configuration.EmailPassword = AESGCM.SimpleDecrypt(configuration.EmailPassword, key256, nonSecretOrg.Length);
        }

    }
}
