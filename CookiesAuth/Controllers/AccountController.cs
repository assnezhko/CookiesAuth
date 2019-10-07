using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CookiesAuth.Models.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using CookiesAuth.Models; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Services;
using CookiesAuth.Models.ODT;

namespace CookiesAuth.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly ISecurityService _securityService;

        public AccountController(IIdentityService identityService, ISecurityService securityService)
        {
            _identityService = identityService;
            _securityService = securityService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)//проверка валидации
            {
                var user = await _identityService.GetUserAsync(model.Email);
                if (user != null)
                {
                    var checkResult = _securityService.verifyMd5Hash(model.Password, user.PasswordHash);

                    if(checkResult)
                    {
                        await Authenticate(model.Email); // аутентификация

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _identityService.GetUserAsync(model.Email);

                if (user == null)
                {
                    var passwordHash = _securityService.getMd5Hash(model.Password);

                    var userModel = new UserModel {
                        Email = model.Email,
                        PasswordHash = passwordHash,
                        IsAdmin = false
                    };

                    // добавляем пользователя в бд
                    await _identityService.AddAsync(userModel);

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}