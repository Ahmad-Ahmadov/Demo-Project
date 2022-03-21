using Core.Entities.Concrete;
using FluentValidation;

namespace Business.CrossCuttingConcerns.Validation.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => String.IsNullOrWhiteSpace(x.FirstName)).NotEqual(true);
            RuleFor(x => String.IsNullOrWhiteSpace(x.LastName)).NotEqual(true);
            RuleFor(x => x.FirstName).MinimumLength(3);
            RuleFor(x => x.LastName).MinimumLength(3);
            RuleFor(x => x.Email).MinimumLength(10);
            RuleFor(x => x.FirstName).MaximumLength(50);
            RuleFor(x => x.LastName).MaximumLength(50);
            RuleFor(x => x.Email).MaximumLength(80);
        }
    }
}
