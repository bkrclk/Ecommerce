using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Validations
{
    public class PaymentValidation : AbstractValidator<PaymentModel>
    {
        public PaymentValidation()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please input valid Name.")
                .Length(3, 20).WithMessage("Username min 3 max 20 characters")
                .Matches(@"^[a-zA-ZÖöıİşçÇğĞÜüŞ''-'\s]+$").WithMessage("Special character cannot be entered");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Please input valid Surname.")
                .Length(3, 20).WithMessage("Username min 3 max 20 characters")
                .Matches(@"^[a-zA-ZÖöıİşçÇğĞÜüŞ''-'\s]+$").WithMessage("Special character cannot be entered");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please input valid Email.")
                .Matches(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$").WithMessage("Not a valid email");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Please input valid Phone.")
                .Length(3, 20).WithMessage("Username min 3 max 20 characters")
                .Matches(@"^\(?([0]{1}[5]{1}[3-5]{1}[0-9]{1})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").WithMessage("Phone 0553 - XXX - XXXX && 553XXXXXXX entered.");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Please input valid Adress.")
                .Length(10, 100).WithMessage("Username min 10 max 100 characters");

            RuleFor(x => x.CardName)
                .NotEmpty().WithMessage("Please input valid CardName.")
                .Length(5, 20).WithMessage("Username min 5 max 20 characters")
                .Matches(@"^[a-zA-ZÖöıİşçÇğĞÜüŞ''-'\s]+$").WithMessage("Special character cannot be entered");

            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage("Please input valid CardNumber.")
                .Length(16, 19).WithMessage("Card Number of 16 digit input.")
                .Matches(@"^\d{4}-?\d{4}-?\d{4}-?\d{4}$").WithMessage("Please input enter valid card number");

            RuleFor(x => x.CardExpirationDate)
               .NotEmpty().WithMessage("Please input valid CardExpirationDate.")
               .MinimumLength(5).WithMessage("input invalid.")
               .Matches(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$").WithMessage("input invalid.");

            RuleFor(x => x.CardCVV)
             .NotEmpty().WithMessage("Please input valid CardCVV.")
             .MinimumLength(3).WithMessage("input invalid.");
        }

    }
}
