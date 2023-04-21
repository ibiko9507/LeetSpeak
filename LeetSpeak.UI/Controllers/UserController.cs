using Microsoft.AspNetCore.Mvc;

namespace LeetSpeak.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
