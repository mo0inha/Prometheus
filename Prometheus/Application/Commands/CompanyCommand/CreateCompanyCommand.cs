using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.CompanyRequest;
using Domain.Response.CompanyResponse;

namespace Application.Commands.CompanyCommand
{
    public class CreateCompanyCommand : BaseCommand<Company, CreateCompanyRequest, CreateCompanyResponse>
    {
        public CreateCompanyCommand(IRepository repository) : base(repository)
        {
        }

        protected override Task BeforeChanges(CreateCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Task<Company> Changes(CreateCompanyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
