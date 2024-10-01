using AutoMapper;
using InstaConnect.Follows.Business.Features.Users.Mappings;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Data.Features.Users.Abstractions;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Users.Utilities;

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
        InvalidUserId = GetAverageString(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);

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
