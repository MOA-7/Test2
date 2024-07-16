using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace Test2.services
{
	public class mailsender : IEmailSender
	{
		private string smtpserver;
		private int smtpport;
		private string FromemailAddress;

		public mailsender(string smtpserver, int smtpport, string FromemailAddress)
		{
			this.smtpserver = smtpserver;
			this.smtpport = smtpport;
			this.FromemailAddress = FromemailAddress;
		}

		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var massge = new MailMessage
			{
				From = new MailAddress(FromemailAddress),
				Subject = subject,
				Body = htmlMessage,
				IsBodyHtml = true
			};
			massge.To.Add(new MailAddress(email));

			using var client = new SmtpClient(smtpserver, smtpport);
			client.Send(massge);
			return Task.CompletedTask;
		}
	}
}
