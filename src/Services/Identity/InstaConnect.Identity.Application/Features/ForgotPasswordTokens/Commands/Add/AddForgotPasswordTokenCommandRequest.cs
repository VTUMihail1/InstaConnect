namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;

public record AddForgotPasswordTokenCommandRequest(string Name) : ICommandRequest;
