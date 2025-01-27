using Domain.Request;
using FluentValidation;

namespace Application.Validator
{
    public class CreateTenantValidator : AbstractValidator<CreateTenantRequest>
    {
        public CreateTenantValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("funcionou pae");
        }
    }
}
