﻿namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Abstractions;
public interface IForgotPasswordTokenPublisher
{
    Task PublishForgotPasswordTokenAsync(CreateForgotPasswordTokenModel createForgotPasswordTokenModel, CancellationToken cancellationToken);
}
