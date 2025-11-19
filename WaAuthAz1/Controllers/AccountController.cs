using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WaAuthAz1.Controllers;

public class AccountController : Controller
{
    [Authorize]
    public IActionResult Test()
    {
        return RedirectToAction("Index", "Home");
    }

    public IActionResult SignIn()
    {
        return Challenge(
            new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            },
            OpenIdConnectDefaults.AuthenticationScheme);
    }

    [Authorize]
    public IActionResult SignOutUser()
    {
        return SignOut(
            new AuthenticationProperties
            {
                RedirectUri = Url.Action("LoggedOut", "Account")
            },
            CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public IActionResult LoggedOut()
    {
        return View();
    }
}