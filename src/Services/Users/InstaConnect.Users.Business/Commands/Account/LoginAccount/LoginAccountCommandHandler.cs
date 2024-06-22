using AutoMapper;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction;
using InstaConnect.Users.Data.Models.Filters;

namespace InstaConnect.Users.Business.Commands.Account.LoginAccount;

public class LoginAccountCommandHandler : ICommandHandler<LoginAccountCommand, AccountViewModel>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenRepository _tokenRepository;
    private readonly IUserClaimRepository _userClaimRepository;

    public LoginAccountCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ITokenGenerator tokenGenerator,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenRepository tokenRepository,
        IUserClaimRepository userClaimRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenRepository = tokenRepository;
        _userClaimRepository = userClaimRepository;
    }

    public async Task<AccountViewModel> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
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

        var filteredCollectionQuery = _mapper.Map<UserClaimFilteredCollectionQuery>(existingUser);
        var userClaims = await _userClaimRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);

        var createAccessModel = _mapper.Map<CreateAccessTokenModel>(existingUser);
        _mapper.Map(userClaims, createAccessModel);

        var token = _tokenGenerator.GenerateAccessToken(createAccessModel);
        _tokenRepository.Add(token);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountViewDTO = _mapper.Map<AccountViewModel>(token);

        return accountViewDTO;
    }
}


