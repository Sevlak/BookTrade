using BookTrade.Application.Services;
using BookTrade.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTrade.Web.Controllers;

public class AccountController : Controller
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _userService.LoginUserAsync(model.Username, model.Password);

        if (result.Succeeded) return RedirectToAction("Index", "Home");

        ModelState.AddModelError(nameof(model.Username), "Invalid username or password");

        return View(model);
    }

    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var result = await _userService.CreateUserAsync(model.Email, model.Username, model.Password);

        if (result.Succeeded) return RedirectToAction("Login", "Account");

        /*TODO: Using a foreach here will not work. It only uses the first error. Need to find an alternative.
                Perhaps we could use asp-validation-summary?
        */
        foreach (var error in result.Errors)
            switch (error.Code)
            {
                case "DuplicateUserName":
                    ModelState.AddModelError(nameof(model.Username), "Username already exists");
                    break;
                case "PasswordRequiresNonAlphanumeric":
                    ModelState.AddModelError(nameof(model.Password), "Password must contain at least one non-alphanumeric character");
                    break;
                case "PasswordRequiresDigit":
                    ModelState.AddModelError(nameof(model.Password), "Password must contain at least one digit");
                    break;
                case "PasswordRequiresLower":
                    ModelState.AddModelError(nameof(model.Password), "Password must contain at least one lowercase character");
                    break;
                case "PasswordRequiresUpper":
                    ModelState.AddModelError(nameof(model.Password), "Password must contain at least one uppercase character");
                    break;
                case "DuplicateEmail":
                    ModelState.AddModelError(nameof(model.Email), "Email already exists");
                    break;
            }

        return View(model);
    }
}