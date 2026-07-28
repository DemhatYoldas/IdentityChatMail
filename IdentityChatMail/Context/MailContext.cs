using IdentityChatMail.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityChatMail.Context
{
    public class MailContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JQG1QG1\\SQLEXPRESS;initial Catalog=MailChatDb;integrated Security=true;trust server certificate=true;");
        }

        public DbSet<Message> Messages { get; set; }

    }
}
