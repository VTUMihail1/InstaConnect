using AutoMapper;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Common.Utilities;
using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BaseEmailConfirmationTokenUnitTest()
    {
        CancellationToken = new CancellationToken();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<EmailConfirmationTokenCommandProfile>())));
    }

    private User CreateUserUtil()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage);

        return user;
    }

    protected User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }

    private EmailConfirmationToken CreateEmailConfirmationTokenUtil(User user)
    {
        var emailConfirmationToken = new EmailConfirmationToken(
            SharedTestUtilities.GetGuid(),
            SharedTestUtilities.GetMaxDate(),
            user);

        return emailConfirmationToken;
    }

    protected EmailConfirmationToken CreateEmailConfirmationToken()
    {
        var user = CreateUser();
        var emailConfirmationToken = CreateEmailConfirmationTokenUtil(user);

        return emailConfirmationToken;
    }
}
