using Entities.Concrete;
using FluentValidation;

namespace Business.CrossCuttingConcerns.Validation.FluentValidation
{
    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(p => String.IsNullOrWhiteSpace(p.Name)).NotEqual(true);
            RuleFor(p => p.Name).MinimumLength(3);
            RuleFor(p => p.Name).MaximumLength(30);
        }
    }
}
