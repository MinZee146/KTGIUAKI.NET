using Microsoft.AspNetCore.Mvc;
using WebECommerce.Models;
using System.Linq;

namespace WebECommerce.Controllers
{
    public class AuthController : Controller
    {
        private readonly QlbanVaLiContext _context;

        public AuthController(QlbanVaLiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                ViewData["usernameError"] = "Please provide a username.";
            }
            else if (string.IsNullOrEmpty(password))
            {
                ViewData["passwordError"] = "Please provide your password.";
            }
            else
            {
                var user = _context.TUsers.SingleOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    return RedirectToAction("", "Home");
                }
                else
                {
                    ViewData["loginError"] = "Invalid username or password.";
                }
            }

            return View("Index");
        }

        [HttpPost]
        public IActionResult Signup(string usernameSignup, string passwordSignup, string passwordConfirm)
        {
            if (string.IsNullOrEmpty(usernameSignup))
            {
                ViewData["usernameSignupError"] = "Please provide a username.";
            }
            else if (string.IsNullOrEmpty(passwordSignup))
            {
                ViewData["passwordSignupError"] = "Please provide a password.";
            }
            else if (string.IsNullOrEmpty(passwordConfirm))
            {
                ViewData["confirmError"] = "Please confirm your password.";
            }
            else if (passwordSignup != passwordConfirm)
            {
                ViewData["confirmError"] = "Passwords don't match.";
            }
            else
            {
                if (_context.TUsers.Any(u => u.Username == usernameSignup))
                {
                    ViewData["usernameSignupError"] = "Username is already taken.";
                }
                else
                {
                    var newUser = new TUser
                    {
                        Username = usernameSignup,
                        Password = passwordSignup 
                    };
                    _context.TUsers.Add(newUser);
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Auth");
                }
            }

            // Return to the main view with any validation errors
            return View("Index");
        }
    }
}
