using Domain.Request;
using FluentValidation;

namespace Application.Validator
{
    public class UpdateTenantValidator : AbstractValidator<UpdateTenantRequest>
    {
        public UpdateTenantValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(10).WithMessage("funcionou pae");
        }
    }
}
