using ForumDeDiscussion.Data.Context;
using ForumDeDiscussion.Helpers;
using ForumDeDiscussion.Models;
using ForumDeDiscussion.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;

namespace ForumDeDiscussion.Controllers
{
    public class AuthController : Controller
    {
        private readonly ForumDeDiscussionDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public AuthController(ILogger<HomeController> logger, ForumDeDiscussionDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _context.membre.AnyAsync(m => m.UserName == viewModel.UserName || m.Email == viewModel.Email);
                if (existingUser)
                {
                    ModelState.AddModelError("", "Un utilisateur avec ce nom ou cet email existe déjà.");
                    return View(viewModel);
                }

                string hashedPassword = CryptographyHelper.HashPassword(viewModel.Password);

                var newMember = new Membre
                {
                    Name = viewModel.Name,
                    Firstname = viewModel.Firstname,
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    Password = hashedPassword,
                };

                _context.membre.Add(newMember);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel viewModel = new();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel, string? returnurl)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.membre.FirstOrDefaultAsync(m => m.Email == viewModel.Email);

                if (user != null)
                {
                    bool isValid = CryptographyHelper.ValidateHashedPassword(viewModel.Password, user.Password);

                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Email, viewModel.Email),
                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity));

                        if (!string.IsNullOrWhiteSpace(returnurl) && Url.IsLocalUrl(returnurl))
                        {
                            return LocalRedirect(returnurl);
                        }

                        return RedirectToAction("Index", "Home");
                    }
                }
                //else
                //{
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    _logger.LogWarning("User not found.");
                //}
            }

            return View(viewModel);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

    }
}
