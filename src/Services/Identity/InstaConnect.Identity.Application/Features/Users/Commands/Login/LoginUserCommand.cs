namespace InstaConnect.Identity.Application.Features.Users.Commands.Login;

public record LoginUserCommand(string Email, string Password) : ICommandRequest<UserTokenCommandViewModel>;
