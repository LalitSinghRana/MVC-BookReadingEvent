using FluentValidation.Results;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Validations
{
    public static class ValidationExtensions
    {
        public static NagarroBookEventValidationResult ToValidationResult(this ValidationResult result)
        {
            IList<NagarroBookEventValidationFailure> errors = new List<NagarroBookEventValidationFailure>();

            foreach (ValidationFailure failure in result.Errors)
            {
                errors.Add(failure.ToValidationFailure());
            }

            return new NagarroBookEventValidationResult(errors);
        }

        public static NagarroBookEventValidationFailure ToValidationFailure(this ValidationFailure failure)
        {
            return new NagarroBookEventValidationFailure(failure.PropertyName, failure.ErrorMessage, failure.AttemptedValue);
        }

    }
}
