using System;
using System.Diagnostics;


namespace demoapi.Services
{
    public class CloudMailService : IMailService
    {
		private string _mailTo = "admin@mycompany.com";
		private string _mailFrom = "noreply@mycompany.com";


		public void Send(string subject, string message)
		{
			Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService");
			Debug.WriteLine($"Subject: {subject} ");
			Debug.WriteLine($"Message: {message} ");
		}
    }
}
