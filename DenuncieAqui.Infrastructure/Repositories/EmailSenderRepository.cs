using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DenuncieAqui.Infrastructure.Data;

public class EmailSenderRepository : IEmailSender<ApplicationUser>
{
    private readonly IConfiguration _configuration;

    public EmailSenderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Método para enviar e-mails
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var emailSettings = _configuration.GetSection("EmailSettings");

        var smtpClient = new SmtpClient(emailSettings["SMTPServer"]) // Corrigido para usar a chave de servidor SMTP
        {
            Port = int.Parse(emailSettings["SMTPPort"]), // Corrigido para pegar a porta correta
            Credentials = new NetworkCredential(emailSettings["SMTPUsername"], emailSettings["SMTPPassword"]),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(emailSettings["FromEmail"]), // Pega o e-mail do remetente da configuração
            Subject = subject,
            Body = message,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(email);

        await smtpClient.SendMailAsync(mailMessage);
    }

    // Método para enviar o link de confirmação de e-mail
    public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
    {
        string subject = "Confirm your email";
        string message = $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(confirmationLink)}'>link</a>";
        await SendEmailAsync(email, subject, message);
    }

    // Método para enviar o código de reset de senha (não está sendo usado, mas implementado para completude)
    public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        string subject = "Reset your password code";
        string message = $"Your password reset code is: {HtmlEncoder.Default.Encode(resetCode)}";
        await SendEmailAsync(email, subject, message);
    }

    // Método para enviar o link de reset de senha
    public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string callbackUrl)
    {
        string subject = "Reset your password";
        string message = $"Please reset your password by clicking this link: <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>link</a>";
        await SendEmailAsync(email, subject, message);
    }
}
