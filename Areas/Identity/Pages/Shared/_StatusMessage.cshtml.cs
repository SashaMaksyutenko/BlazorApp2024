using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

public class StatusMessageModel : PageModel
{
    public string? DisplayMessage { get; private set; }

    public void OnGet(string? message)
    {
        // Отримання повідомлення із запиту або з кукі
        DisplayMessage = message ?? Request.Cookies["StatusMessageCookieName"];

        // Видалення кукі, якщо повідомлення отримано з нього
        if (DisplayMessage != null)
        {
            Response.Cookies.Delete("StatusMessageCookieName");
        }
    }
}
