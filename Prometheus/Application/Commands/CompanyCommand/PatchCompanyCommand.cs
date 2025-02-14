using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.CompanyRequest;
using Domain.Response.CompanyResponse;

namespace Application.Commands.CompanyCommand
{
    public class PatchCompanyCommand : BaseCommand<Company, PatchCompanyRequest, PatchCompanyResponse>
    {
        public PatchCompanyCommand(IRepository repository) : base(repository)
        {
        }

        protected override Task BeforeChanges(PatchCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Task<Company> Changes(PatchCompanyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
