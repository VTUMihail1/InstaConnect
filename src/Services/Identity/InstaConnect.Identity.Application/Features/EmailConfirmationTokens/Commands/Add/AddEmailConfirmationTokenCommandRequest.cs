using Microsoft.AspNetCore.Http;

namespace InstaConnect.EmailConfirmationTokens.Application.Features.EmailConfirmationTokens.Commands.Add;

public record AddEmailConfirmationTokenCommandRequest(string Name) : ICommandRequest;
