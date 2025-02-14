using AutoMapper;
using InstaConnect.Identity.Application.Extensions;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Mappings;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Common.Helpers;
using InstaConnect.Shared.Common.Utilities;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IEmailConfirmationTokenWriteRepository EmailConfirmationTokenWriteRepository { get; }

    protected IEmailConfirmationTokenPublisher EmailConfirmationTokenPublisher { get; }

    public BaseEmailConfirmationTokenUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(ApplicationReference.Assembly))));
        CancellationToken = new CancellationToken();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        EmailConfirmationTokenWriteRepository = Substitute.For<IEmailConfirmationTokenWriteRepository>();
        EmailConfirmationTokenPublisher = Substitute.For<IEmailConfirmationTokenPublisher>();
    }

    private User CreateUserUtil(bool isEmailConfirmed)
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            UserTestUtilities.ValidPasswordHash,
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength))
        {
            IsEmailConfirmed = isEmailConfirmed
        };

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        UserWriteRepository.GetByNameAsync(user.UserName, CancellationToken)
            .Returns(user);

        UserWriteRepository.GetByEmailAsync(user.Email, CancellationToken)
            .Returns(user);

        return user;
    }

    protected User CreateUser()
    {
        var user = CreateUserUtil(false);

        return user;
    }

    public User CreateUserWithConfirmedEmail()
    {
        var user = CreateUserUtil(true);

        return user;
    }

    public EmailConfirmationToken CreateEmailConfirmationTokenUtil(User user)
    {
        var emailConfirmationToken = new EmailConfirmationToken(
            SharedTestUtilities.GetGuid(),
            SharedTestUtilities.GetMaxDate(),
            user);

        EmailConfirmationTokenWriteRepository.GetByValueAsync(emailConfirmationToken.Value, CancellationToken)
            .Returns(emailConfirmationToken);

        return emailConfirmationToken;
    }

    public EmailConfirmationToken CreateEmailConfirmationToken()
    {
        var user = CreateUser();
        var emailConfirmationToken = CreateEmailConfirmationTokenUtil(user);

        return emailConfirmationToken;
    }

    public EmailConfirmationToken CreateEmailConfirmationTokenWithConfirmedUser()
    {
        var user = CreateUserWithConfirmedEmail();
        var emailConfirmationToken = CreateEmailConfirmationTokenUtil(user);

        return emailConfirmationToken;
    }
}
