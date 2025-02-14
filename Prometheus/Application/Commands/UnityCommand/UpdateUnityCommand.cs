using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.UnityRequest;
using Domain.Response.UnityResponse;

namespace Application.Commands.UnityCommand
{
    public class UpdateUnityCommand : BaseCommand<Unity, UpdateUnityRequest, UpdateUnityResponse>
    {
        public UpdateUnityCommand(IRepository repository) : base(repository)
        {
        }

        protected override Task BeforeChanges(UpdateUnityRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Task<Unity> Changes(UpdateUnityRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
