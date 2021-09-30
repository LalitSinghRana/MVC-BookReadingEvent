using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Business
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 5)
        {
            var options = ruleBuilder
                .MinimumLength(minimumLength).WithMessage(Constant.UserValidationPasswordLength)
                .Matches("[^a-zA-Z0-9]").WithMessage(Constant.UserValidationPasswordChar);
            return options;
        }
    }
}