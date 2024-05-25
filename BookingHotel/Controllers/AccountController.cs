﻿using BookingHotel.Data;
using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using static BookingHotel.Models.AccountViewModels;
using System.Security.Principal;

namespace BookingHotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly HotelContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public object AllowRefresh { get; private set; }
        public bool IsPersistent { get; private set; }

        public AccountController(HotelContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Username) ||
                    string.IsNullOrEmpty(model.Password) ||
                    string.IsNullOrEmpty(model.ConfirmPassword) ||
                    string.IsNullOrEmpty(model.Name) ||
                    string.IsNullOrEmpty(model.PhoneNumber))
                {
                    ModelState.AddModelError("", "Vui lòng điền đầy đủ thông tin.");
                    return View(model);
                }
                var existingUsername = _context.Accounts.FirstOrDefault(a => a.username == model.Username);
                if (existingUsername != null)
                {
                    ModelState.AddModelError("", "Tên người dùng đã được sử dụng.");
                    return View(model);
                }

                var existingPhoneNumber = _context.Accounts.FirstOrDefault(a => a.phoneNumber == model.PhoneNumber);
                if (existingPhoneNumber != null)
                {
                    ModelState.AddModelError("", "Số điện thoại đã được sử dụng.");
                    return View(model);
                }

                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Mật khẩu không khớp.");
                    return View(model);
                }

                var account = new Account
                {
                    username = model.Username,
                    password = model.Password,
                    name = model.Name,
                    phoneNumber = model.PhoneNumber,
                    role = "User"
                };
                
                _context.Accounts.Add(account);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            if (claimsPrincipal.Identity.IsAuthenticated) { 
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = _context.Accounts.FirstOrDefault(a => a.username == model.Username && a.password == model.Password);
                if (account != null)
                {
                    //var claims = new[]
                    //{
                    //    new Claim(ClaimTypes.Name, model.Username),
                    //};

                    //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    //await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    //return RedirectToAction("Index", "Home");

                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim (ClaimTypes.NameIdentifier,model.Username),
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim("OtherProperties","Examole Role")
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = true
                    };

                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new  ClaimsPrincipal(identity), properties);

                    return RedirectToAction("Index", "Home");
            }
                //ViewData["ValidationMessage"] = "Không tìm thấy người dùng";
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
