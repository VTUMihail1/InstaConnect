using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.ConfirmUserEmail;

public record ConfirmUserEmailCommand(string UserId, string Token) : ICommand;
