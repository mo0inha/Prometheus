using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.UnityRequest;
using Domain.Response.UnityResponse;

namespace Application.Commands.UnityCommand
{
    public class PatchUnityCommand : BaseCommand<Unity, PatchUnityRequest, PatchUnityResponse>
    {
        public PatchUnityCommand(IRepository repository) : base(repository)
        {
        }

        protected override Task BeforeChanges(PatchUnityRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Task<Unity> Changes(PatchUnityRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
