using System.Net;
using System.Net.Mail;
using System.Text;
public class MailUtils
{
  public static async Task<string> SendMail(string _from, string _to, string _subject, string _body)
  {
    MailMessage mailMessage = new MailMessage();
    mailMessage.BodyEncoding = Encoding.UTF8;
    mailMessage.SubjectEncoding = Encoding.UTF8;
    mailMessage.IsBodyHtml = true;
    mailMessage.ReplyToList.Add(new MailAddress(_from));
    mailMessage.Sender = new MailAddress(_from);
    using var smtpClient = new SmtpClient("localhost");
    try
    {
      await smtpClient.SendMailAsync(mailMessage);
      return "Gui email thanh cong";
    }
    catch (System.Exception)
    {

      return "Gui email that bai";
      throw;
    }
  }
  public static async Task<string> SendGMail(string _from, string _to, string _subject, string _body, string _gmail, string _pass)
  {
    MailMessage mailMessage = new MailMessage(_from, _to, _subject, _body);
    mailMessage.BodyEncoding = Encoding.UTF8;
    mailMessage.SubjectEncoding = Encoding.UTF8;
    mailMessage.IsBodyHtml = true;
    mailMessage.ReplyToList.Add(new MailAddress(_from));
    mailMessage.Sender = new MailAddress(_from);

    using var smtpClient = new SmtpClient("smtp.gmail.com");
    smtpClient.Port = 587;
    smtpClient.EnableSsl = true;
    smtpClient.Credentials = new NetworkCredential(_gmail, _pass);

    try
    {
      await smtpClient.SendMailAsync(mailMessage);
      return "Gui email thanh cong";
    }
    catch (System.Exception)
    {

      return "Gui email that bai";
      throw;
    }
  }
}