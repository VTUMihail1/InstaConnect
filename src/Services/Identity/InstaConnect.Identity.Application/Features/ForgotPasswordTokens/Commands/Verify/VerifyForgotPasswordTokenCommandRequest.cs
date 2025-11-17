using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Models;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

public record VerifyForgotPasswordTokenCommandRequest(
    ForgotPasswordTokenIdPayload Id,
    string Password,
    string ConfirmPassword) : ICommandRequest;
