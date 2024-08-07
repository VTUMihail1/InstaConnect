using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Data.Features.Tokens.Abstractions;
using InstaConnect.Identity.Data.Features.Tokens.Models;
using InstaConnect.Identity.Data.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.LoginAccount;

public class LoginAccountCommandHandler : ICommandHandler<LoginAccountCommand, AccountTokenCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUserClaimWriteRepository _userClaimWriteRepository;

    public LoginAccountCommandHandler(
        IUnitOfWork unitOfWork,
        ITokenGenerator tokenGenerator,
        IPasswordHasher passwordHasher,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IUserClaimWriteRepository userClaimWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _tokenGenerator = tokenGenerator;
        _passwordHasher = passwordHasher;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _userClaimWriteRepository = userClaimWriteRepository;
    }

    public async Task<AccountTokenCommandViewModel> Handle(
        LoginAccountCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new AccountInvalidDetailsException();
        }

        var isValidPassword = _passwordHasher.Verify(request.Password, existingUser.PasswordHash);

        if (!isValidPassword)
        {
            throw new AccountInvalidDetailsException();
        }

        var filteredCollectionQuery = _instaConnectMapper.Map<UserClaimFilteredCollectionWriteQuery>(existingUser);
        var userClaims = await _userClaimWriteRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);

        var createAccessModel = _instaConnectMapper.Map<CreateAccessTokenModel>((userClaims, existingUser));
        var token = _tokenGenerator.GenerateAccessToken(createAccessModel);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountViewDTO = _instaConnectMapper.Map<AccountTokenCommandViewModel>(token);

        return accountViewDTO;
    }
}


