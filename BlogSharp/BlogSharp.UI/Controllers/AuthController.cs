using BlogSharp.UI.CustomLibraries;
using BlogSharp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BlogSharp.UI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        public AuthController()
        {

        }
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            List<User> user = new List<User>();
            user = _carRepo.Users();
            var emailCheck = user.FirstOrDefault(u => u.Email == model.Email);
            var getPassword = user.Where(u => u.Email == model.Email).Select(u => u.Password);
            var materializePassword = getPassword.ToList();
            var password = materializePassword[0];
            var decryptedPassword = CustomDecrypt.Decrypt(password);
            if (model.Email != null && model.Password == decryptedPassword)
            {
                var getEmail = user.Where(u => u.Email == model.Email).Select(u => u.Email);
                var materializeEmail = getEmail.ToList();
                var email = materializeEmail[0];

                var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Email, email)
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User model)
        {
            if (ModelState.IsValid)
            {
                User encryptedPwUser = new User()
                {
                    Email = model.Email,
                    Password = CustomEncrypt.Encrypt(model.Password)
                };
                _carRepo.AddUser(model);
            }
            return View();
        }
    }
}