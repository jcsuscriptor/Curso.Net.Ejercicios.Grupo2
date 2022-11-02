using FluentValidation;
using ValidationPractice.Model;

namespace ValidationPractice.Validator
{
    public class AddressValidator : AbstractValidator<Address>
    {

        public AddressValidator()
        {
            RuleFor(a => a.Street1).MaximumLength(80);
            RuleFor(a => a.Street2).MaximumLength(80);
            RuleFor(a => a.Reference).MaximumLength(100);

            RuleFor(a => a)
                .Must(a =>
                {
                    if (string.IsNullOrEmpty(a.Street1)
                        && string.IsNullOrEmpty(a.Reference)
                        && string.IsNullOrEmpty(a.Street2)){
                        return false;
                    }
                    return true;
                })
                .WithMessage("Debe existir por lo menos un valor");
        }
    }
}
