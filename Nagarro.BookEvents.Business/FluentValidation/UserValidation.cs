using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Business
{
    public class UserValidation : AbstractValidator<UserDTO>
    {
        public UserValidation()
        {
            RuleFor(user => user.Email).NotNull().WithMessage(Constant.UserValidationEmail);
            RuleFor(user => user.Password).Password();
            RuleFor(user => user.FullName).NotNull().WithMessage(Constant.UserValidationName);
        }
    }
}
