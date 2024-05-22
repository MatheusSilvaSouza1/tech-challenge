using FluentValidation;

namespace Domain.Validations
{
    public class CreateContactValidation : AbstractValidator<Contact>
    {
        public CreateContactValidation()
        {
            RuleFor(e => e.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.Phone)
                .NotEmpty()
                .NotNull()
                .Matches(@"^\d{8,9}$").WithMessage("'Phone' number must contain 8 or 9 digits."); ;
        }
    }
}