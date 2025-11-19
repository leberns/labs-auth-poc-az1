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

    [Authorize]
    public IActionResult SignOutApp()
    {
        return SignOut(
            new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            },
            CookieAuthenticationDefaults.AuthenticationScheme,
            OpenIdConnectDefaults.AuthenticationScheme);
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

    // Sign out completely from Azure AD and the application
    [Authorize]
    public IActionResult SignOutAzure1()
    {
        return SignOut(
            new AuthenticationProperties
            {
                RedirectUri = Url.Action("LoggedOut", "Account")
            },
            OpenIdConnectDefaults.AuthenticationScheme,
            CookieAuthenticationDefaults.AuthenticationScheme);
    }

    [Authorize]
    public IActionResult SignOutAzure2()
    {
        return SignOut(
            new AuthenticationProperties
            {
                RedirectUri = Url.Action("LoggedOut", "Account")
            },
            CookieAuthenticationDefaults.AuthenticationScheme);
    }

    [Authorize]
    public IActionResult SignOutAzure3()
    {
        return SignOut(
            new AuthenticationProperties
            {
                RedirectUri = Url.Action("LoggedOut", "Account")
            },
            OpenIdConnectDefaults.AuthenticationScheme);
    }

    [Authorize]
    public IActionResult SignOutAzure4()
    {
        return SignOut(
            new AuthenticationProperties
            {
                RedirectUri = Url.Action("LoggedOut", "Account")
            });
    }

    public IActionResult LoggedOut()
    {
        return View();
    }
}