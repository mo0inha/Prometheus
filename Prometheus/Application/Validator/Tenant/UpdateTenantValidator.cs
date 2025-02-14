using Domain.Request.TenantRequest;
using FluentValidation;

namespace Application.Validator.Tenant
{
    public class UpdateTenantValidator : AbstractValidator<UpdateTenantRequest>
    {
        public UpdateTenantValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(10).WithMessage("funcionou pae");
        }
    }
}
