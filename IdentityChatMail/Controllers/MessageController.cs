using IdentityChatMail.Context;
using IdentityChatMail.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var messageList = _context.Messages.Where(x => x.ReceiverEmail == values.Email).ToList();
            return View(messageList);
        }


        public async Task<IActionResult> Sendbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var messageList = _context.Messages.Where(x => x.SenderMail == values.Email).ToList();
            return View(messageList);
        }

        [HttpGet]
        public async Task<IActionResult> CreateMessage()
        {
            return View();
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

            message.SenderMail = user.Email;
            message.SendDate = DateTime.Now;
            message.IsRead = false;

            // Controller içinde doldurduğumuz alanların eski validasyon sonuçlarını kaldırıyoruz
            ModelState.Remove(nameof(message.SenderMail));
            ModelState.Remove(nameof(message.SendDate));
            ModelState.Remove(nameof(message.IsRead));

            if (!ModelState.IsValid)
            {
                return View(message);
            }

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Mesaj başarıyla gönderildi.";
            return RedirectToAction("Sendbox");
        }


        public async Task<IActionResult> MessageDetails(int id)
        {
            var message = await _context.Messages
                .FirstOrDefaultAsync(x => x.MessageId == id);

            if (message == null)
            {
                return NotFound();
            }

            var senderUser = await _userManager.FindByEmailAsync(message.SenderMail);

            

            if (!message.IsRead)
            {
                message.IsRead = true;
                await _context.SaveChangesAsync();
            }



            ViewBag.ProfilImageUrl = senderUser?.ProfilImageUrl;
            ViewBag.Name = senderUser?.Name;
            ViewBag.Surname = senderUser?.Surname;
            ViewBag.Email = senderUser?.Email;

            return View(message);
        }



    }
}
