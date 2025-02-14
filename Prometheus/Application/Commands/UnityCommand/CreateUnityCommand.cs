using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.UnityRequest;
using Domain.Response.UnityResponse;

namespace Application.Commands.UnityCommand
{
    public class CreateUnityCommand : BaseCommand<Unity, CreateUnityRequest, CreateUnityResponse>
    {
        public CreateUnityCommand(IRepository repository) : base(repository)
        {
        }

        protected override Task BeforeChanges(CreateUnityRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Task<Unity> Changes(CreateUnityRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
