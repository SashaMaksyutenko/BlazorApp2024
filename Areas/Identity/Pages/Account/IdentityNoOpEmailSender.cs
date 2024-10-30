using BlazorApp2024.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

internal sealed class IdentityNoOpEmailSender : IEmailSender
{
    private readonly IEmailSender emailSender;

    public IdentityNoOpEmailSender(IEmailSender smtpEmailSender)
    {
        emailSender = smtpEmailSender;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        return emailSender.SendEmailAsync(email, subject, htmlMessage);
    }

    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
        emailSender.SendEmailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
        emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
        emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");
}
