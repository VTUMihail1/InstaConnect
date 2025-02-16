using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Login;

public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, UserTokenCommandViewModel>
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    private readonly IUserClaimWriteRepository _userClaimWriteRepository;

    public LoginUserCommandHandler(
        IPasswordHasher passwordHasher,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IAccessTokenGenerator accessTokenGenerator,
        IUserClaimWriteRepository userClaimWriteRepository)
    {
        _passwordHasher = passwordHasher;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _accessTokenGenerator = accessTokenGenerator;
        _userClaimWriteRepository = userClaimWriteRepository;
    }

    public async Task<UserTokenCommandViewModel> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserInvalidDetailsException();
        }

        var isValidPassword = _passwordHasher.Verify(request.Password, existingUser.PasswordHash);

        if (!isValidPassword)
        {
            throw new UserInvalidDetailsException();
        }

        if (!existingUser.IsEmailConfirmed)
        {
            throw new UserEmailNotConfirmedException();
        }

        var filteredCollectionQuery = _instaConnectMapper.Map<UserClaimCollectionWriteQuery>(existingUser);
        var userClaims = await _userClaimWriteRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);

        var createAccessModel = _instaConnectMapper.Map<CreateAccessTokenModel>((userClaims, existingUser));
        var token = _accessTokenGenerator.GenerateAccessToken(createAccessModel);

        var accountTokenCommandViewModel = _instaConnectMapper.Map<UserTokenCommandViewModel>(token);

        return accountTokenCommandViewModel;
    }
}


