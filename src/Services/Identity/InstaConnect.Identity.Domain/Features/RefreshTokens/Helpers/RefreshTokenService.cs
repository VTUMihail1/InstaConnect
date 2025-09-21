using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;
using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.Users.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;
internal class RefreshTokenService : IRefreshTokenService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserClaimRepository _userClaimRepository;
    private readonly IRefreshTokenFactory _refreshTokenFactory;
    private readonly ISessionTokenFactory _sessionTokenFactory;
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public RefreshTokenService(
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper,
        IUserClaimRepository userClaimRepository,
        IRefreshTokenFactory refreshTokenFactory,
        ISessionTokenFactory sessionTokenFactory,
        IAccessTokenGenerator accessTokenGenerator,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
        _accessTokenGenerator = accessTokenGenerator;
        _userClaimRepository = userClaimRepository;
        _refreshTokenFactory = refreshTokenFactory;
        _sessionTokenFactory = sessionTokenFactory;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<SessionToken> IssueAsync(IssueRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserInvalidDetailsException(command.Name);
        }

        var isMismatch = _passwordHasher.IsMismatch(command.Password, existingUser!.PasswordHash);

        if (isMismatch)
        {
            throw new UserInvalidDetailsException(command.Name);
        }

        var refreshToken = _refreshTokenFactory.Create(existingUser.Id);
        _refreshTokenRepository.Add(refreshToken);

        var claimsRequst = _applicationMapper.Map<GetAllUserClaimsQuery>(existingUser);
        var userClaims = await _userClaimRepository.GetAllAsync(claimsRequst, cancellationToken);
        var accessToken = _accessTokenGenerator.Generate(existingUser, userClaims.Data);
        var sessionToken = _sessionTokenFactory.Create(refreshToken, accessToken);

        return sessionToken;
    }

    public async Task<SessionToken> RotateAsync(RotateRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id);
        }

        var existingRefreshToken = await _refreshTokenRepository.GetByIdAsync(command.Id, command.Value, cancellationToken);

        if (existingRefreshToken.IsNull())
        {
            throw new RefreshTokenNotFoundException(command.Id, command.Value);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();

        if (existingRefreshToken!.HasExpired(utcNow))
        {
            throw new EmailConfirmationTokenExpiredException(command.Id, command.Value);
        }

        _refreshTokenRepository.Delete(existingRefreshToken);

        var refreshToken = _refreshTokenFactory.Create(existingUser!.Id);
        _refreshTokenRepository.Add(refreshToken);

        var claimsRequst = _applicationMapper.Map<GetAllUserClaimsQuery>(existingUser);
        var userClaims = await _userClaimRepository.GetAllAsync(claimsRequst, cancellationToken);
        var accessToken = _accessTokenGenerator.Generate(existingUser, userClaims.Data);
        var sessionToken = _sessionTokenFactory.Create(refreshToken, accessToken);

        return sessionToken;
    }

    public async Task DeleteAsync(DeleteRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id);
        }

        var existingRefreshToken = await _refreshTokenRepository.GetByIdAsync(command.Id, command.Value, cancellationToken);

        if (existingRefreshToken.IsNull())
        {
            throw new RefreshTokenNotFoundException(command.Id, command.Value);
        }

        _refreshTokenRepository.Delete(existingRefreshToken!);
    }
}
