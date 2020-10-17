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

namespace Notify.Services
{
    public class EmailService : IEmailService
    {
        private IHostingEnvironment hostingEnvironment;
        private IConfiguration config;

        public EmailService(IHostingEnvironment hostingEnvironment,
                              IConfiguration config)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.config = config;
        }

        public bool SendEmail(ClientMessage clientMessage)
        {
            var message = new EmailMessage();

            message.Message = clientMessage.Message;
            message.From = "martin@shapeconsulting.com";
            message.Subject = "Welcome Email";
            message.To = config["SmtpOptions:ShapeConsulting:User"];
            message.TextTo = "8044756841@vtext.com";

            var u = config["SmtpOptions:ShapeConsulting:User"].ToString();

            Email.DefaultRenderer = new RazorRenderer();

            var templatePath = config["Templates:Email"];
            var welcomeEmail = new ContactRequestEmail() { Name = clientMessage.Name, Phone = clientMessage.Phone, 
                                                           Email = clientMessage.From, Message = clientMessage.Message  };
            var currentDirectory = Directory.GetCurrentDirectory();

            var email = Email
                            .From(message.From)
                            .To(message.To)
                            .Subject(message.Subject)
                            .UsingTemplateFromFile($"{currentDirectory}/{templatePath}/ContactRequest.cshtml", welcomeEmail);

            var ret = sendEmail(email);

            var sms = Email
                           .From(message.From)
                           .To(message.TextTo)
                           .Subject(message.Subject)
                           .UsingTemplateFromFile($"{currentDirectory}/{templatePath}/ContactRequestText.cshtml", welcomeEmail);

            var smsRet = sendEmail(sms);

            return ret;
        }

        private bool sendEmail(IFluentEmail email)
        {
            var option = new SmtpClientOptions();
            option.Server = config["SmtpOptions:ShapeConsulting:Server"];
            option.User = config["SmtpOptions:ShapeConsulting:User"];
            option.Password = config["SmtpOptions:ShapeConsulting:Password"];
            option.Port = Convert.ToInt32(config["SmtpOptions:ShapeConsulting:Port"]);
            option.RequiresAuthentication = Convert.ToBoolean(config["SmtpOptions:ShapeConsulting:RequiresAuthentication"]);
            option.UseSsl = Convert.ToBoolean(config["SmtpOptions:ShapeConsulting:UseSsl"]);

            email.Sender = new MailKitSender(option);
            email.SendAsync();
            return true;
        }

        //private bool sendEmail(EmailMessage message)
        //{
        //    if (string.IsNullOrWhiteSpace(message.To))
        //    {
        //        throw new ArgumentException("no to address provided");
        //    }

        //    if (string.IsNullOrWhiteSpace(message.From))
        //    {
        //        throw new ArgumentException("no from address provided");
        //    }

        //    if (string.IsNullOrWhiteSpace(message.Subject))
        //    {
        //        throw new ArgumentException("no subject provided");
        //    }

        //    var hasHtml = !string.IsNullOrWhiteSpace(message.Message);
        //    var outMessage = new MimeMessage();

        //    outMessage.From.Add(new MailboxAddress("", message.From));
        //    if (!string.IsNullOrWhiteSpace(message.ReplyTo))
        //    {
        //        outMessage.ReplyTo.Add(new MailboxAddress("", message.ReplyTo));
        //    }

        //    outMessage.To.Add(new MailboxAddress("", message.To));
        //    outMessage.Subject = message.Subject;


        //    if (!string.IsNullOrEmpty(message.Cc))
        //    {
        //        outMessage.Cc.Add(new MailboxAddress("", message.Cc));
        //    }

        //    BodyBuilder bodyBuilder = new BodyBuilder();

        //    if (hasHtml)
        //    {
        //        bodyBuilder.HtmlBody = message.Message;
        //    }

        //    outMessage.Body = bodyBuilder.ToMessageBody();

        //    using (var client = new SmtpClient())
        //    {
        //        client.Connect(
        //           message.SmtpOptions.Server,
        //           message.SmtpOptions.Port,
        //           message.SmtpOptions.UseSsl
        //         );

        //        // Note: since we don't have an OAuth2 token, disable
        //        // the XOAUTH2 authentication mechanism.
        //        client.AuthenticationMechanisms.Remove("XOAUTH2");

        //        // Note: only needed if the SMTP server requires authentication
        //        if (message.SmtpOptions.RequiresAuthentication)
        //        {
        //            client.Authenticate(message.SmtpOptions.User, message.SmtpOptions.Password);
        //        }

        //        client.Send(outMessage);
        //        client.Disconnect(true);
        //    }

        //    return true;

        //}
    }
}
