namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;

public record AddEmailConfirmationTokenCommandRequest(string Name) : ICommandRequest;
