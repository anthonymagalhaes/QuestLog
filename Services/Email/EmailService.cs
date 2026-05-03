using System;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using QuestLog.Configuration;

namespace QuestLog.Services.Email
{

    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly IConfiguration _configuration;

        public EmailService(IOptions<EmailConfiguration> emailConfig, IConfiguration configuration)
        {
            _emailConfig = emailConfig.Value;
            _configuration = configuration;
        }

        public async Task SendEmail(string toName, string toEmail, string subject, string body, bool isHtml = false)
        {
            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress(_emailConfig.SenderName, _emailConfig.SenderEmail));
            mensagem.To.Add(new MailboxAddress(toName, toEmail));
            mensagem.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            if (isHtml)
                bodyBuilder.HtmlBody = body;
            else
                bodyBuilder.TextBody = body;
            mensagem.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.Auto);
                await client.AuthenticateAsync(_emailConfig.SmtpUsername, _emailConfig.Password);
                await client.SendAsync(mensagem);
                Console.WriteLine($"E-mail enviado com sucesso para {toEmail}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao enviar e-mail para {toEmail}: \n{ex.ToString()}");
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }

        public async Task EmailRecover(string email, string token,string name)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RecoverEmail.html");
            string htmlBody = await File.ReadAllTextAsync(filePath);

            string frontendUrl = _configuration["FrontendUrl"];
            var url = $"{frontendUrl}/recover?token={token}";

            htmlBody = htmlBody.Replace("{{LinkDaUrl}}", url);
            htmlBody = htmlBody.Replace("{{Username}}", name);
            
            await SendEmail(
                toName: name,
                toEmail: email,
                subject: "QuestLog - Recuperação de Conta",
                body: htmlBody,
                isHtml: true
            );
        }
    }
}