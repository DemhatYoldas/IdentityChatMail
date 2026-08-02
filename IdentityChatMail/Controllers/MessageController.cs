using IdentityChatMail.Context;
using IdentityChatMail.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityChatMail.Controllers
{
    [Authorize]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
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
            var values = await _userManager.FindByNameAsync(User.Identity!.Name!);

            if (values == null || string.IsNullOrEmpty(values.Email))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var messageList = await _context.Messages
                .Where(x =>
                    x.ReceiverEmail == values.Email &&
                    !x.ReceiverIsDeleted)
                .OrderByDescending(x => x.SendDate)
                .ToListAsync();

            return View(messageList);
        }

        public async Task<IActionResult> Sendbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var messageList = await _context.Messages.Where(x =>x.SenderMail == values.Email &&!x.SenderIsDeleted).OrderByDescending(x => x.SendDate).ToListAsync();
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

            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var currentUser = await _userManager.FindByNameAsync(userName);

            if (currentUser == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

            // Kullanıcının bu mesajı görme yetkisi var mı?
            if (message.SenderMail != currentUser.Email &&
                message.ReceiverEmail != currentUser.Email)
            {
                return Forbid();
            }

            var senderUser = await _userManager
                .FindByEmailAsync(message.SenderMail);

            if (message.ReceiverEmail == currentUser.Email &&
                !message.IsRead)
            {
                message.IsRead = true;
                await _context.SaveChangesAsync();
            }

            ViewBag.CurrentUserEmail = currentUser.Email;

            ViewBag.ProfilImageUrl = senderUser?.ProfilImageUrl;
            ViewBag.Name = senderUser?.Name;
            ViewBag.Surname = senderUser?.Surname;
            ViewBag.Email = senderUser?.Email;

            return View(message);
        }



        [HttpGet]
        public async Task<IActionResult> ToggleImportant(int id)
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var currentUser = await _userManager.FindByNameAsync(userName);

            if (currentUser == null || string.IsNullOrEmpty(currentUser.Email))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var userEmail = currentUser.Email;

            var message = await _context.Messages
                .FirstOrDefaultAsync(x =>
                    x.MessageId == id &&
                    (x.SenderMail == userEmail ||
                     x.ReceiverEmail == userEmail));

            if (message == null)
            {
                return NotFound();
            }

            if (message.ReceiverEmail == userEmail)
            {
                message.ReceiverIsImportant =
                    !message.ReceiverIsImportant;
            }
            else if (message.SenderMail == userEmail)
            {
                message.SenderIsImportant =
                    !message.SenderIsImportant;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("MessageDetails", new
            {
                id = message.MessageId
            });
        }



        public async Task<IActionResult> Important()
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var currentUser = await _userManager.FindByNameAsync(userName);

            if (currentUser == null || string.IsNullOrEmpty(currentUser.Email))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var userEmail = currentUser.Email;

            var messages = await _context.Messages
                .Where(x =>
                    (x.ReceiverEmail == userEmail && x.ReceiverIsImportant) ||
                    (x.SenderMail == userEmail && x.SenderIsImportant))
                .OrderByDescending(x => x.SendDate)
                .ToListAsync();

            return View(messages);
        }




        [HttpGet]
        public async Task<IActionResult> MoveToTrash(int id)
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var currentUser = await _userManager.FindByNameAsync(userName);

            if (currentUser == null || string.IsNullOrEmpty(currentUser.Email))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var userEmail = currentUser.Email;

            var message = await _context.Messages
                .FirstOrDefaultAsync(x =>
                    x.MessageId == id &&
                    (x.SenderMail == userEmail ||
                     x.ReceiverEmail == userEmail));

            if (message == null)
            {
                return NotFound();
            }

            if (message.ReceiverEmail == userEmail)
            {
                message.ReceiverIsDeleted = true;
            }
            else if (message.SenderMail == userEmail)
            {
                message.SenderIsDeleted = true;
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Mesaj çöp kutusuna taşındı.";

            return RedirectToAction("Inbox");
        }


        public async Task<IActionResult> Trash()
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var currentUser = await _userManager.FindByNameAsync(userName);

            if (currentUser == null || string.IsNullOrEmpty(currentUser.Email))
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var userEmail = currentUser.Email;

            var messages = await _context.Messages
                .Where(x =>
                    (x.ReceiverEmail == userEmail && x.ReceiverIsDeleted) ||
                    (x.SenderMail == userEmail && x.SenderIsDeleted))
                .OrderByDescending(x => x.SendDate)
                .ToListAsync();

            return View(messages);
        }

    }
}
