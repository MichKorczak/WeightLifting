using System;
using System.Threading.Tasks;
using Data.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Services.Interfaces;
using WeightLifting.Extensions;

namespace WeightLifting.Controllers
{
    [Authorize]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailSender emailSender;
        private readonly ILogger logger;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender, ILogger<ApplicationUser> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Registration registration, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {UserName = registration.Mail, Email = registration.Mail };
                var resoult = await userManager.CreateAsync(user, registration.Password); // zastanawiam się czy nie dodać tego do servisu i najwyżej tylko tutaj wywołac funckję 
                if (resoult.Succeeded)
                {
                    logger.LogInformation("User created a new account with password");

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user); 
                    var callbackUrl = Url.EmailConfirmationLink(registration.Mail, code, Request.Scheme);
                    await emailSender.SendEmailConfirmationAsync(registration.Mail, callbackUrl);

                    await signInManager.SignInAsync(user, isPersistent: false);
                    logger.LogInformation(3, "User created a new account with password");
                    return RedirectToAction(nameof(ViewController.Index), $"View");
                }

                AddErrors(resoult);
            }

            return View(login); // Wiem że nie ma widoku ale coś mi musi zwracać a jeszcze chyba nie doczytałem innej opcji :)
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login, string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var resoult = await signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe,
                    lockoutOnFailure: false); 
                if (resoult.Succeeded)
                {
                    logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(login);
                } // wiem że tutaj można dodać inne warunki ale wstępnie chce się dowiedzieć czy to jest spoko czy należało by to poprawić 
            }

            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            logger.LogInformation(4, "User logged out");
            return RedirectToAction(nameof(ViewController.Index), "View");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return RedirectToAction(nameof(ViewController.Index), $"View");
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                throw new ApplicationException($"Unable to load user with '{userId}'.");
            var resoult = await userManager.ConfirmEmailAsync(user, code);
            return View(resoult.Succeeded ? "ConfirmEmail" : "Error");
        }


        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect((returnUrl));
            else
                return RedirectToAction(nameof(ViewController.Index), $"View");

        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
