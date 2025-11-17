using InstaConnect.Common.Application.Models;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;

public record AddForgotPasswordTokenCommandRequest(NamePayload Name) : ICommandRequest;
