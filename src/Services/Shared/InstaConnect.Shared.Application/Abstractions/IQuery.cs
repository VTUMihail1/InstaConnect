using MediatR;

namespace InstaConnect.Shared.Business.Abstractions;

public interface IQuery<TResponse> : IRequest<TResponse>;
