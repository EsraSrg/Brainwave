using BookReviewIdentity.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewIdentity.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Bu alana elliden fazla karakter girilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lürfen geçerli bir mail adresi giriniz.");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Girdiğiniz şifreler aynı değil.");
        }
    }
}
