using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace demoapi.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo;
        private string _mailFrom;

        private IConfiguration _configuration;


        public LocalMailService(IConfiguration configuration) 
        {
            _configuration = configuration;
            _mailTo = _configuration["MailSettings:mailToAddress"];
            _mailFrom = _configuration["MailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message) 
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService");
            Debug.WriteLine($"Subject: {subject} ");
            Debug.WriteLine($"Message: {message} ");
        }

    }
}
