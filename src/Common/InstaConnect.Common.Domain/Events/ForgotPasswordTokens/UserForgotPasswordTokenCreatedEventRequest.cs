using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Application.Contracts.ForgotPasswordTokens;

public record UserForgotPasswordTokenCreatedEventRequest(string Email, string RedirectUrl)
    : IEventRequest;
