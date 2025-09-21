using Microsoft.AspNetCore.Http;

namespace InstaConnect.ForgotPasswordTokens.Application.Features.ForgotPasswordTokens.Commands.Add;

public record VerifyForgotPasswordTokenCommandRequest(
    string Id,
    string Value,
    string Password,
    string ConfirmPassword) : ICommandRequest;
