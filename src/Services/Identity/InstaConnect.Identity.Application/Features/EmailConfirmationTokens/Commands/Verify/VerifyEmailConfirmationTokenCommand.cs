using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;

public record VerifyEmailConfirmationTokenCommand(string UserId, string Token) : ICommand;
