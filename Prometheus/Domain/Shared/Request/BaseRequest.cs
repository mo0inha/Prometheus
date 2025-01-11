using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Request
{
    public class BaseRequest<TResponse> : IRequest<TResponse>
    {
        private Guid Id;

        public void SetId(Guid id)
        {
            Id = id;
        }

        public Guid GetId()
        {
            return Id;
        }
    }
}
