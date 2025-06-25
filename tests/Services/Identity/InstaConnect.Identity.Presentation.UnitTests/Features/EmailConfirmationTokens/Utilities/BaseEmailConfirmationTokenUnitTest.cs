using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entities;
using InstaConnect.Identity.Presentation.Extensions;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IApplicationSender ApplicationSender { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected BaseEmailConfirmationTokenUnitTest()
    {
        CancellationToken = new CancellationToken();
        ApplicationSender = Substitute.For<IApplicationSender>();
        ApplicationMapper = new ApplicationMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PresentationReference.Assembly))));
    }

    private static User CreateUserUtil()
    {
        var user = new User(
            DataFaker.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            DataFaker.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage);

        return user;
    }

    protected static User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }

    private static EmailConfirmationToken CreateEmailConfirmationTokenUtil(User user)
    {
        var emailConfirmationToken = new EmailConfirmationToken(
            DataFaker.GetGuid(),
            DataFaker.GetMaxDate(),
            user);

        return emailConfirmationToken;
    }

    protected static EmailConfirmationToken CreateEmailConfirmationToken()
    {
        var user = CreateUser();
        var emailConfirmationToken = CreateEmailConfirmationTokenUtil(user);

        return emailConfirmationToken;
    }
}
