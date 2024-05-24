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
                .NotNull();

            RuleFor(e => e.DDDId)
            .NotEmpty()
            .NotNull();
        }
    }
}