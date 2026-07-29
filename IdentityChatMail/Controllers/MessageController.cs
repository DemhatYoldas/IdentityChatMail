using IdentityChatMail.Context;
using IdentityChatMail.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatMail.Controllers
{
    public class MessageController : Controller
    {
        private readonly MailContext _context;
        private readonly UserManager<AppUser> _userManager;

    

        public MessageController(MailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public async Task<IActionResult> Inbox()
        {
            //var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //var messageList = _context.Messages.Where(x => x.ReceiverEmail == values.Email).ToList();
            return View(/*messageList*/);
        }


        public async Task<IActionResult> Sendbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var messageList = _context.Messages.Where(x => x.SenderMail == values.Email).ToList();
            return View(messageList);
        }
    }
}
