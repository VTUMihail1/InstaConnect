﻿using AutoMapper;

using InstaConnect.Identity.Application.Extensions;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Common.Helpers;

namespace InstaConnect.Identity.Application.UnitTests.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPasswordHasher PasswordHasher { get; }

    protected IForgotPasswordTokenWriteRepository ForgotPasswordTokenWriteRepository { get; }

    protected IForgotPasswordTokenPublisher ForgotPasswordTokenPublisher { get; }

    protected BaseForgotPasswordTokenUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
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
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
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
            SharedTestUtilities.GetGuid(),
            SharedTestUtilities.GetMaxDate(),
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
