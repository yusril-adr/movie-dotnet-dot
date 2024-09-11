using System.Net;
using System.Net.Mail;
using Coravel.Invocable;
using dot_dotnet_test_api.Types;

public class EmailInvocable : IInvocableWithPayload<EmailMessage>, IInvocable
{
  public EmailMessage Payload { get; set; }
  private readonly SmtpClient _smtpClient;

  private readonly IConfiguration _configuration;

  public EmailInvocable(IConfiguration configuration)
  {
    _configuration = configuration;
    _smtpClient = new SmtpClient("smtp.gmail.com")
    {
      Port = 587,
      Credentials = new NetworkCredential(configuration["Gmail:email"], configuration["Gmail:password"]),
      EnableSsl = true,
    };
  }

  public async Task Invoke()
  {
    Console.WriteLine("Email send");
    _smtpClient.Send(_configuration["Gmail:email"]!, Payload.To, Payload.Subject, Payload.Body);
  }
}
