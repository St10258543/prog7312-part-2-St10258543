using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

public class LanguageController : Controller
{
    public IActionResult SetLanguage(string lang, string returnUrl)
    {
        if (!string.IsNullOrEmpty(lang))
        {
            // Create or update a cookie to store the selected language
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName, 
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(lang) 
                ),
                new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1), 
                    IsEssential = true 
                }
            );
        }
        return LocalRedirect(returnUrl ?? "/");
    }
}
