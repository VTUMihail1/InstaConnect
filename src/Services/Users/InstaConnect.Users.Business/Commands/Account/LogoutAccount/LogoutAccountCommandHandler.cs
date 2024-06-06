using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Abstractions;

namespace InstaConnect.Users.Business.Commands.Account.LogoutAccount;

public class LogoutAccountCommandHandler : ICommandHandler<LogoutAccountCommand>
{
    private readonly ITokenService _tokenService;

    public LogoutAccountCommandHandler(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public async Task Handle(LogoutAccountCommand request, CancellationToken cancellationToken)
    {
        await _tokenService.DeleteAsync(request.Value, cancellationToken);
    }
}
