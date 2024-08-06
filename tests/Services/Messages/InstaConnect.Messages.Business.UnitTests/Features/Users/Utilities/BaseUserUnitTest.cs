using AutoMapper;
using InstaConnect.Messages.Business.Features.Messages.Utilities;
using InstaConnect.Messages.Business.Features.Users.Mappings;
using InstaConnect.Messages.Data.Features.Users.Abstract;
using InstaConnect.Messages.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidCurrentUserId;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;

    protected IUserReadRepository UserReadRepository { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    public BaseUserUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<UserConsumerProfile>()))),
        new EntityPropertyValidator())
    {
        InvalidUserId = GetAverageString(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);

        UserReadRepository = Substitute.For<IUserReadRepository>();
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

        UserReadRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);
    }
}
