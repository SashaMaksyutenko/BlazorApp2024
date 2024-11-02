using System.Threading.Tasks;
using BlazorApp2024.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

internal sealed class IdentityNoOpEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Логування або обробка, що електронний лист надіслано
        Console.WriteLine($"Email sent to: {email}\nSubject: {subject}\nMessage: {htmlMessage}");

        // Повертаємо завершене завдання без фактичного надсилання
        return Task.CompletedTask;
    }
    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
        LogEmailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
        LogEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
        LogEmailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");

    private Task LogEmailAsync(string email, string subject, string htmlMessage)
    {
        Console.WriteLine($"Email sent to: {email}\nSubject: {subject}\nMessage: {htmlMessage}");

        return Task.CompletedTask;
    }
}
