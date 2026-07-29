using Microsoft.AspNetCore.Mvc;

namespace IdentityChatMail.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
