using AutoMapper;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.Account.LoginAccount;

public class LoginAccountCommandHandler : ICommandHandler<LoginAccountCommand, AccountViewDTO>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenRepository _tokenRepository;

    public LoginAccountCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ITokenGenerator tokenGenerator,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenRepository tokenRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenRepository = tokenRepository;
    }

    public async Task<AccountViewDTO> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new AccountInvalidDetailsException();
        }

        var isValidPassword = _passwordHasher.Verify(request.Password, existingUser.PasswordHash);

        if (!isValidPassword)
        {
            throw new AccountInvalidDetailsException();
        }

        var token = _tokenGenerator.GenerateAccessToken(existingUser.Id);
        _tokenRepository.Add(token);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountViewDTO = _mapper.Map<AccountViewDTO>(token);

        return accountViewDTO;
    }
}
