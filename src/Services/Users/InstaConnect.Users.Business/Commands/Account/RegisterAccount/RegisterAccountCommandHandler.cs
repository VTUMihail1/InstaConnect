using AutoMapper;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Models.Entities;

namespace InstaConnect.Users.Business.Commands.Account.RegisterAccount;

public class RegisterAccountCommandHandler : ICommandHandler<RegisterAccountCommand>
{
    private readonly IMapper _mapper;
    private readonly IAccountManager _accountManager;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public RegisterAccountCommandHandler(
        IMapper mapper,
        IUserRepository userRepository,
        IAccountManager accountManager,
        ITokenService tokenService)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _accountManager = accountManager;
        _tokenService = tokenService;
    }

    public async Task Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        var existingEmailUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingEmailUser != null)
        {
            throw new AccountEmailAlreadyTakenException();
        }

        var existingNameUser = await _userRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingNameUser != null)
        {
            throw new AccountUsernameAlreadyTakenException();
        }

        var user = _mapper.Map<User>(request);
        await _accountManager.RegisterUserAsync(user, request.Password);

        var tokenViewDTO = await _tokenService.GenerateAccessTokenAsync(user.Id, cancellationToken);
    }
}
