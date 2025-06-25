using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Identity.Application.Extensions;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models;

namespace InstaConnect.Identity.Application.UnitTests.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPasswordHasher PasswordHasher { get; }

    protected IForgotPasswordTokenWriteRepository ForgotPasswordTokenWriteRepository { get; }

    protected IForgotPasswordTokenPublisher ForgotPasswordTokenPublisher { get; }

    protected BaseForgotPasswordTokenUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        ApplicationMapper = new ApplicationMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(ApplicationReference.Assembly))));
        CancellationToken = new CancellationToken();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PasswordHasher = Substitute.For<IPasswordHasher>();
        ForgotPasswordTokenWriteRepository = Substitute.For<IForgotPasswordTokenWriteRepository>();
        ForgotPasswordTokenPublisher = Substitute.For<IForgotPasswordTokenPublisher>();

        PasswordHasher.Hash(UserTestUtilities.ValidUpdatePassword)
            .Returns(new PasswordHashResultModel(UserTestUtilities.ValidUpdatePasswordHash));
    }

    private User CreateUserUtil(bool isEmailConfirmed)
    {
        var user = new User(
            DataFaker.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            DataFaker.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage)
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
        var user = CreateUserUtil(true);

        return user;
    }

    private ForgotPasswordToken CreateForgotPasswordTokenUtil(User user)
    {
        var forgotPasswordToken = new ForgotPasswordToken(
            DataFaker.GetGuid(),
            DataFaker.GetMaxDate(),
            user);

        ForgotPasswordTokenWriteRepository.GetByValueAsync(forgotPasswordToken.Value, CancellationToken)
            .Returns(forgotPasswordToken);

        return forgotPasswordToken;
    }

    protected ForgotPasswordToken CreateForgotPasswordToken()
    {
        var user = CreateUser();
        var forgotPasswordToken = CreateForgotPasswordTokenUtil(user);

        return forgotPasswordToken;
    }
}
