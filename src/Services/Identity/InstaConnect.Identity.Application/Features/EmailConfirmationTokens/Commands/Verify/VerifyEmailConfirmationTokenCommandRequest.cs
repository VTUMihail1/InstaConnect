namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;

public record VerifyEmailConfirmationTokenCommandRequest(string Id, string Value) : ICommandRequest;
