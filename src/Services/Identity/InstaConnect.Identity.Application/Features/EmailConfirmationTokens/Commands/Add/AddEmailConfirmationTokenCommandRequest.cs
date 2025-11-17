using InstaConnect.Common.Application.Models;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;

public record AddEmailConfirmationTokenCommandRequest(NamePayload Name) : ICommandRequest;
