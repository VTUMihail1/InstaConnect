using Microsoft.AspNetCore.Http;

namespace InstaConnect.ForgotPasswordTokens.Application.Features.ForgotPasswordTokens.Commands.Add;

public record AddForgotPasswordTokenCommandRequest(string Name) : ICommandRequest;
