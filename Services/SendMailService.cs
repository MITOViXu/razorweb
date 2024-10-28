using System;
using System.Threading.Tasks;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Album.Mail
{

  // Cấu hình dịch vụ gửi mail, giá trị Inject từ appsettings.json
  public class MailSettings
  {
    public string Mail { get; set; }
    public string DisplayName { get; set; }
    public string Password { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }

  }

  // Dịch vụ gửi mail
  public class SendMailService : IEmailSender
  {
    private readonly MailSettings mailSettings;

    private readonly ILogger<SendMailService> logger;

    // mailSetting được Inject qua dịch vụ hệ thống
    // Có inject Logger để xuất log
    public SendMailService(IOptions<MailSettings> _mailSettings, ILogger<SendMailService> _logger)
    {
      mailSettings = _mailSettings.Value;
      logger = _logger;
      logger.LogInformation("Create SendMailService");
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {

      var message = new MimeMessage();
      message.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
      message.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
      message.To.Add(MailboxAddress.Parse(email));
      message.Subject = subject;

      var builder = new BodyBuilder
      {
        HtmlBody = htmlMessage
      };
      message.Body = builder.ToMessageBody();

      // Use SmtpClient from MailKit
      using var smtp = new MailKit.Net.Smtp.SmtpClient();

      try
      {
        smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
        await smtp.SendAsync(message);
      }
      catch (Exception ex)
      {
        // On failure, save the email to a local file for review
        System.IO.Directory.CreateDirectory("mailssave");
        var emailsavefile = $"mailssave/{Guid.NewGuid()}.eml";
        await message.WriteToAsync(emailsavefile);

        logger.LogInformation($"Failed to send email, saved to - {emailsavefile}");
        logger.LogError(ex.Message);
      }
      finally
      {
        smtp.Disconnect(true);
      }

      logger.LogInformation($"Email sent to: {email}");
    }
  }
}