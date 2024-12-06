using IntergalacticConflict.Core.Dto;
using IntergalacticConflict.Core.ServiceInterface;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterGalacticConflict.ApplicationServices.Services
{
    public class EmailServices : IEmailsServices
    {
        private readonly IConfiguration _configuration;


        public EmailServices(IConfiguration configuration)
        {
             _configuration = configuration;
        }

        public void SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();

            _configuration.GetSection("EmailUserName").Value = "Battlefrontmailee";
            _configuration.GetSection("EmailHost").Value = "smtp.gmail.com";
            _configuration.GetSection("EmailPassword").Value = "zglz oapc wqvs mkeq";

            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body,
            };
            
            
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            //Maybe later USe googlsstmp to generate password, can find in account settins, sth app password
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }


        public void SendEmailToken(EmailTokenDto dto, string token)
        {
            dto.Token = token;
            var email = new MimeMessage();

            _configuration.GetSection("EmailUserName").Value = "Battlefrontmailee";
            _configuration.GetSection("EmailHost").Value = "smtp.gmail.com";
            _configuration.GetSection("EmailPassword").Value = "zglz oapc wqvs mkeq";

            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body += dto.Token
            };


            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            //Maybe later USe googlsstmp to generate password, can find in account settins, sth app password
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }


    
}
