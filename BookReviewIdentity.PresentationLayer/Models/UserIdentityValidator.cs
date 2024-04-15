using Microsoft.AspNetCore.Identity;

namespace BookReviewIdentity.PresentationLayer.Models
{
    public class UserIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordToShort",
                Description = $"Parola en az {length} karakter olmalıdır."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Parolada en az bir büyük harf olmalıdır."
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Parolada en az bir büyük harf olmalıdır."
            };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError()
            {
                Code = "PasswordMismatch",
                Description = "Girdiğiniz parolalar aynı olmalıdır."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            { 
                Code = "PasswordRequiresDigit",
                Description = "Parolada en az bir sayı olmalıdır."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parolada en az bir sembol olmalıdır."
            };
        }
    }
}
