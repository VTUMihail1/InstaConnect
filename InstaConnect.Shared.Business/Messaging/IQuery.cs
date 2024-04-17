using MediatR;

namespace InstaConnect.Shared.Business.Messaging
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
