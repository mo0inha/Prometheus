using Domain.Request.TenantRequest;
using FluentValidation;

namespace Application.Validator.Tenant
{
    public class CreateTenantValidator : AbstractValidator<CreateTenantRequest>
    {
        public CreateTenantValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
