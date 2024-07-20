﻿using MediatR;

namespace InstaConnect.Shared.Business.Abstractions;
public interface IInstaConnectSender
{
    Task SendAsync<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest;

    Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
}