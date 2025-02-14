using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.CompanyRequest;
using Domain.Response.CompanyResponse;

namespace Application.Commands.CompanyCommand
{
    public class DeleteCompanyCommand : BaseCommand<Company, DeleteCompanyRequest, DeleteCompanyResponse>
    {
        public DeleteCompanyCommand(IRepository repository) : base(repository)
        {
        }

        protected override Task BeforeChanges(DeleteCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Task<Company> Changes(DeleteCompanyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
