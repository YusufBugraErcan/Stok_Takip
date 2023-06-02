using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using stoktakip.data;
using stoktakip.Models;

namespace stoktakip.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly stoktakipDBContext db;
        public LoginController(ILogger<LoginController> logger, stoktakipDBContext _db)
        {
            _logger = logger;
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/login")]
        public IActionResult LoginUserPage(string errorMessage = "")
        {
            
            if (HttpContext.Session.GetString("role") != null)
            {
                var role = HttpContext.Session.GetString("role");
                System.Diagnostics.Debug.WriteLine(role);
            }
            ViewBag.ErrorMessage = errorMessage;
            return View();

        }

        [Route("/Login/login")]
        [HttpPost]
        public IActionResult loginUser(users user)
        {
            //Form'dan user gelecek. Role'ü alabilmek için join işlemi ile birlikte
            //user modelinden gelen username ve userpass'i where içerisinde sorguladım.
            // if (u != null) ile boş mu diye check ettim. Değilse Session içerisine yazdım.
            
            users u = db.users.Where(m => m.username == user.username && m.userpass == user.userpass)
                   .FirstOrDefault();
            if (u != null)
            {
                HttpContext.Session.SetString("role", u.roleId.ToString());
                
            }
            else
            {
                string errorMessage = "Kullanıcı adı veya şifre hatalı!";
                return RedirectToAction("LoginUserPage", new { errorMessage });
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("/Login/logout")]
        public IActionResult Logout()
        {
            
            HttpContext.Session.Clear();

            
            return RedirectToAction("Index", "Home");
        }





    }
}
