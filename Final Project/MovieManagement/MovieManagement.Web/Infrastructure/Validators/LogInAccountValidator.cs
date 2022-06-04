using FluentValidation;
using MovieManagement.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Web.Infrastructure.Validators
{
    public class LogInAccountValidator : AbstractValidator<RegisterUserRequest>
    {
        public LogInAccountValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Your username con not be empty.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Your username con not be empty.");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Your username con not be empty.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password can not be empty")
                    .MinimumLength(6).WithMessage("Your password length must be at least 6.")
                    .MaximumLength(20).WithMessage("Your password length must not exceed 20.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Your username con not be empty.")
                .EmailAddress().WithMessage("Wrong email format.");
        }
    }
}