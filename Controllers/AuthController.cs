using System.Security.Claims;
using Blog.Data;
using Blog.Data.Services.Interface;
using Blog.Models;
using Blog.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AuthController : Controller
    {

        public BlogContext _context;
        public IAuthRepository _authRepository;
        public AuthController(BlogContext context, IAuthRepository authRepository)
        {
            _context = context;
            _authRepository = authRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var password = _authRepository.EncryptePassword(user.Password);

            var U = new User()
            {
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Password = password,
                IsAdmin = false,
            };

            _context.Users.Add(U);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var U = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            
            if(U == null || !_authRepository.CheckPassword(U.Password,user.Password)){
                ModelState.AddModelError("Email","This User Was Not Founded !");
                return View(user);
            }
            
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.NameIdentifier,U.Id.ToString()),
            };

            var IdentityClaims = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var PrincipalClaims = new ClaimsPrincipal(IdentityClaims);

            var properties = new AuthenticationProperties(){
                IsPersistent = true
            };
            HttpContext.SignInAsync(PrincipalClaims,properties);

            return U.IsAdmin == true ? Redirect("/Admin/Index") : Redirect("/User/Index");
        }

        [Authorize]
        public IActionResult Logout()
        {
            // ...
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

    }

}