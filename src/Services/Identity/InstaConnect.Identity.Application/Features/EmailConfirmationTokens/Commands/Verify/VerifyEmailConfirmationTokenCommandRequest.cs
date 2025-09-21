using Microsoft.AspNetCore.Http;

namespace InstaConnect.EmailConfirmationTokens.Application.Features.EmailConfirmationTokens.Commands.Add;

public record VerifyEmailConfirmationTokenCommandRequest(
    string Id,
    string Value) : ICommandRequest;
