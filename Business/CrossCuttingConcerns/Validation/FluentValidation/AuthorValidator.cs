using Entities.Concrete;
using FluentValidation;

namespace Business.CrossCuttingConcerns.Validation.FluentValidation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(p=>String.IsNullOrWhiteSpace(p.FirstName)).NotEqual(true);
            RuleFor(p=>String.IsNullOrWhiteSpace(p.LastName)).NotEqual(true);
        }
    }
}
