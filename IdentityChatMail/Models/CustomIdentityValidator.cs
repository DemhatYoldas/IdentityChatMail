using Microsoft.AspNetCore.Identity;

namespace IdentityChatMailDay.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lütfen en az bir büyük harf içeren bir şifre girin."
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen en az bir küçük harf içeren bir şifre girin."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Lütfen en az bir rakam içeren bir şifre girin."
            };

        }


        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Lütfen en az {6 + length} karakter uzunluğunda bir şifre girin."
            };
        }


        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError() { Code = "PasswordRequiresNonAlphanumeric", Description = "Lütfen en az bir özel karakter içeren bir şifre girin." };
        }
    }
}
