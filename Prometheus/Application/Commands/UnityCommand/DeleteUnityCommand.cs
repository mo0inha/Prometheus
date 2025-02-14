using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.UnityRequest;
using Domain.Response.UnityResponse;

namespace Application.Commands.UnityCommand
{
    public class DeleteUnityCommand : BaseCommand<Unity, DeleteUnityRequest, DeleteUnityResponse>
    {
        public DeleteUnityCommand(IRepository repository) : base(repository)
        {
        }

        protected override Task BeforeChanges(DeleteUnityRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Task<Unity> Changes(DeleteUnityRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
