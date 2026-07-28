using Microsoft.AspNetCore.Mvc;

namespace IdentityChatMail.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
