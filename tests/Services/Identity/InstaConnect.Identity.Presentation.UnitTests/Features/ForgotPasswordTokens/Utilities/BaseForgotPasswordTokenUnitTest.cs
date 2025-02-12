using AutoMapper;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Common.Utilities;
using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BaseForgotPasswordTokenUnitTest()
    {
        CancellationToken = new CancellationToken();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<ForgotPasswordTokenCommandProfile>())));
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

    private ForgotPasswordToken CreateForgotPasswordTokenUtil(User user)
    {
        var forgotPasswordToken = new ForgotPasswordToken(
            SharedTestUtilities.GetGuid(),
            SharedTestUtilities.GetMaxDate(),
            user);

        return forgotPasswordToken;
    }

    protected ForgotPasswordToken CreateForgotPasswordToken()
    {
        var user = CreateUser();
        var forgotPasswordToken = CreateForgotPasswordTokenUtil(user);

        return forgotPasswordToken;
    }
}
