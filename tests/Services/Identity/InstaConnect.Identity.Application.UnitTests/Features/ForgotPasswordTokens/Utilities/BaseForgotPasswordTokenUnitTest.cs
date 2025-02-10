using AutoMapper;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Mappings;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Common.Utilities;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;

public abstract class BaseForgotPasswordTokenUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPasswordHasher PasswordHasher { get; }

    protected IForgotPasswordTokenWriteRepository ForgotPasswordTokenWriteRepository { get; }

    protected IForgotPasswordTokenPublisher ForgotPasswordTokenPublisher { get; }

    public BaseForgotPasswordTokenUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<ForgotPasswordTokenCommandProfile>())));
        CancellationToken = new CancellationToken();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PasswordHasher = Substitute.For<IPasswordHasher>();
        ForgotPasswordTokenWriteRepository = Substitute.For<IForgotPasswordTokenWriteRepository>();
        ForgotPasswordTokenPublisher = Substitute.For<IForgotPasswordTokenPublisher>();

        PasswordHasher.Hash(UserTestUtilities.ValidUpdatePassword)
            .Returns(new PasswordHashResultModel(UserTestUtilities.ValidUpdatePasswordHash));
    }

    public User CreateUser()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage);

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        UserWriteRepository.GetByNameAsync(user.UserName, CancellationToken)
            .Returns(user);

        UserWriteRepository.GetByEmailAsync(user.Email, CancellationToken)
            .Returns(user);

        return user;
    }

    public ForgotPasswordToken CreateForgotPasswordToken()
    {
        var user = CreateUser();
        var forgotPasswordToken = new ForgotPasswordToken(
            SharedTestUtilities.GetGuid(),
            SharedTestUtilities.GetMaxDate(),
            user.Id);

        ForgotPasswordTokenWriteRepository.GetByValueAsync(forgotPasswordToken.Value, CancellationToken)
            .Returns(forgotPasswordToken);

        return forgotPasswordToken;
    }
}
