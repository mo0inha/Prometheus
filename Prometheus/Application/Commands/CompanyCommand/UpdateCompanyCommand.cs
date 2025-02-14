using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.CompanyRequest;
using Domain.Response.CompanyResponse;

namespace Application.Commands.CompanyCommand
{
    public class UpdateCompanyCommand : BaseCommand<Company, UpdateCompanyRequest, UpdateCompanyResponse>
    {
        public UpdateCompanyCommand(IRepository repository) : base(repository)
        {
        }

        protected override Task BeforeChanges(UpdateCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Task<Company> Changes(UpdateCompanyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
