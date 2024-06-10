using BookingHotel.Data;
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
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly HotelContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;



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
        public IActionResult Register([Bind("Username,Password,ConfirmPassword,Name,PhoneNumber")] AccountViewModels model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Username) ||
                    string.IsNullOrEmpty(model.Password) ||
                    string.IsNullOrEmpty(model.ConfirmPassword) ||
                    string.IsNullOrEmpty(model.Name) ||
                    string.IsNullOrEmpty(model.PhoneNumber))
                {
                    TempData["ErrorMessage"] = "Please complete all information.";
                    return View(model);
                }
                var existingUsername = _context.Accounts.FirstOrDefault(a => a.username == model.Username);
                if (existingUsername != null)
                {
                    TempData["ErrorMessage"] = "Username already exists";
                    return View(model);
                }
                var existingPhoneNumber = _context.Accounts.FirstOrDefault(a => a.phoneNumber == model.PhoneNumber);
                if (existingPhoneNumber != null)
                {
                    TempData["ErrorMessage"] = "The phone number is already in use.";
                    return View(model);
                }

                if (model.Password != model.ConfirmPassword)
                {
                    TempData["ErrorMessage"] = "Password and ConfirmPassword incorrect.";
                    return View(model);
                }

                var account = new Account
                {
                    username = model.Username,
                    password = model.Password,
                    name = model.Name,
                    phoneNumber = model.PhoneNumber,
                    role = "0"
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
        public async Task<IActionResult> Login(AccountViewModels model)
        {

                var account = _context.Accounts.FirstOrDefault(a => a.username == model.Username && a.password == model.Password);
                if (account != null)
                {
                    var role = account.role;
                    List<Claim> claims = new List<Claim>()
                    {
                        //new Claim (ClaimTypes.NameIdentifier,model.Username),
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim(ClaimTypes.Role, role),
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                   

                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new  ClaimsPrincipal(identity));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Username or password is incorrect";
                }
               
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please complete all information.";
            }
            
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult UserProfile()
        {
            // Lấy tên người dùng từ Claims
            string username = HttpContext.User.Identity.Name;

            // Tìm kiếm thông tin tài khoản trong cơ sở dữ liệu
            var account = _context.Accounts.FirstOrDefault(a => a.username == username);

            if (account == null)
            { 
                return RedirectToAction("Index", "Home"); 
            }

            var requests = _context.Requests
            .Where(r => r.accountID == account.accountID)
            .Include(r => r.RoomType)
            .OrderByDescending(r => r.dateCheckIn)
            .ToList();
            var model = new AccountViewModels
            {
                Username = username,
                Name = account.name,
                PhoneNumber = account.phoneNumber,
                Requests = requests
            };   
            return View(model);
        }

       
    }

}

