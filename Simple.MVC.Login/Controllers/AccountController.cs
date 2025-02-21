using Microsoft.AspNetCore.Mvc;

namespace Simple.MVC.Login.Controllers
{
    public class AccountController : Controller
    {
        private const string HardcodedUsername = "admin";
        private const string HardcodedPassword = "password";

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) &&
                username == HardcodedUsername && password == HardcodedPassword)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Invalid login credentials.";
            return View();
        }
    }
}
