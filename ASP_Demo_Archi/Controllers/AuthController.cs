using ASP_Demo_Archi.Models;
using ASP_Demo_Archi.Tools;
using ASP_Demo_Archi_DAL.Models;
using ASP_Demo_Archi_DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ASP_Demo_Archi.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly SessionManager _session;

        public AuthController(IUserRepo userRepo, SessionManager session)
        {
            _userRepo = userRepo;
            _session = session;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterForm form)
        {
            if(!ModelState.IsValid)
                return View(form);

            //string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashPassword = BCrypt.Net.BCrypt.HashPassword(form.Password);


            try
            {
                _userRepo.Register(form.Email, hashPassword, form.Nickname);
                return RedirectToAction("Login");
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                return View(form);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if(!ModelState.IsValid) return View(form);

            string pwdFromDB = _userRepo.GetHashPwd(form.Email);

            if (BCrypt.Net.BCrypt.Verify(form.Password, pwdFromDB))
            {

                User connectedUser = _userRepo.Login(form.Email, pwdFromDB);

                _session.CurrentUser = connectedUser;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Error");

        }

        public IActionResult Logout()
        {
            _session.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
