﻿using AutoMapper;
using InstaConnect.Posts.Business.Features.Posts.Utilities;
using InstaConnect.Posts.Business.Features.Users.Mappings;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidCurrentUserId;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;

    protected IUserWriteRepository UserWriteRepository { get; }

    public BaseUserUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<UserConsumerProfile>()))),
        new EntityPropertyValidator())
    {
        InvalidUserId = GetAverageString(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);

        UserWriteRepository = Substitute.For<IUserWriteRepository>();

        var existingUser = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidCurrentUserId,
        };

        UserWriteRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);
    }
}
