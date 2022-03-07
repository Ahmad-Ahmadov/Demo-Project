using Entities.Concrete;
using FluentValidation;

namespace Business.CrossCuttingConcerns.Validation.FluentValidation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(p=>p.Name).NotEmpty();
            RuleFor(p=>String.IsNullOrWhiteSpace(p.Name)).NotEqual(true);

            RuleFor(p=>p.AuthorId).NotEmpty();
            RuleFor(p=>p.AuthorId).GreaterThanOrEqualTo(1);

            RuleFor(p=>p.BookPhoto).NotNull();

            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Price).NotNull();
        }
    }
}
