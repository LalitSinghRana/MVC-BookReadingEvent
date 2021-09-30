using FluentValidation;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Business
{
    public class EventValidation : AbstractValidator<EventDTO>
    {
        public EventValidation()
        {
            RuleFor(events => events.Title).NotNull().WithMessage(Constant.EventValidationTitle);
            RuleFor(events => events.Date).NotNull().WithMessage(Constant.EventValidationDate);
            RuleFor(events => events.Location).NotNull().WithMessage(Constant.EventValidationLocation);
            RuleFor(events => events.Type).NotNull().WithMessage(Constant.EventValidationType);
        }
    }
}
