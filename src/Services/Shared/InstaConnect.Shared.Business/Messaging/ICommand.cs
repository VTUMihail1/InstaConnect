using MediatR;

namespace InstaConnect.Shared.Business.Messaging;

public interface ICommand : IRequest
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
