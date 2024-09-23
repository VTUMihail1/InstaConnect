using AutoMapper;
using InstaConnect.Follows.Business.Features.Follows.Mappings;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Follows.Data.Features.Follows.Abstractions;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Follows.Data.Features.Follows.Models.Filters;
using InstaConnect.Follows.Data.Features.Users.Abstractions;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;

public abstract class BaseFollowUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string InvalidId;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidFollowingId;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;
    protected readonly string ValidFollowFollowingId;
    protected readonly string ValidFollowCurrentUserId;

    protected IUserReadRepository UserReadRepository { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IFollowReadRepository FollowReadRepository { get; }

    protected IFollowWriteRepository FollowWriteRepository { get; }

    public BaseFollowUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<FollowQueryProfile>();
                    cfg.AddProfile<FollowCommandProfile>();
                }))),
        new EntityPropertyValidator())
    {
        ValidId = GetAverageString(FollowBusinessConfigurations.ID_MAX_LENGTH, FollowBusinessConfigurations.ID_MIN_LENGTH);
        InvalidId = GetAverageString(FollowBusinessConfigurations.ID_MAX_LENGTH, FollowBusinessConfigurations.ID_MIN_LENGTH);
        ValidFollowingId = GetAverageString(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH);
        InvalidUserId = GetAverageString(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidFollowFollowingId = GetAverageString(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH);
        ValidFollowCurrentUserId = GetAverageString(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);

        UserReadRepository = Substitute.For<IUserReadRepository>();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        FollowReadRepository = Substitute.For<IFollowReadRepository>();
        FollowWriteRepository = Substitute.For<IFollowWriteRepository>();

        var existingFollower = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidCurrentUserId,
        };

        var existingFollowFollower = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidFollowCurrentUserId,
        };

        var existingFollowing = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidFollowingId
        };

        var existingFollowFollowing = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidFollowFollowingId
        };

        var existingFollow = new Follow(
            ValidFollowCurrentUserId,
            ValidFollowFollowingId)
        {
            Id = ValidId,
            Follower = existingFollowFollower,
            Following = existingFollowFollowing
        };

        var existingFollowPaginationList = new PaginationList<Follow>(
            [existingFollow],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue);

        FollowReadRepository.GetByIdAsync(
            ValidId,
            CancellationToken)
            .Returns(existingFollow);

        FollowWriteRepository.GetByIdAsync(
            ValidId,
            CancellationToken)
            .Returns(existingFollow);

        FollowReadRepository.GetByFollowerIdAndFollowingIdAsync(
            ValidFollowCurrentUserId,
            ValidFollowFollowingId,
            CancellationToken)
            .Returns(existingFollow);

        FollowWriteRepository.GetByFollowerIdAndFollowingIdAsync(
            ValidFollowCurrentUserId,
            ValidFollowFollowingId,
            CancellationToken)
            .Returns(existingFollow);

        UserReadRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingFollower);

        UserReadRepository.GetByIdAsync(
            ValidFollowingId,
            CancellationToken)
            .Returns(existingFollowing);

        UserReadRepository.GetByIdAsync(
            ValidFollowCurrentUserId,
            CancellationToken)
            .Returns(existingFollowFollower);

        UserReadRepository.GetByIdAsync(
            ValidFollowFollowingId,
            CancellationToken)
            .Returns(existingFollowFollowing);

        UserWriteRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingFollower);

        UserWriteRepository.GetByIdAsync(
            ValidFollowingId,
            CancellationToken)
            .Returns(existingFollowing);

        UserWriteRepository.GetByIdAsync(
            ValidFollowCurrentUserId,
            CancellationToken)
            .Returns(existingFollowFollower);

        UserWriteRepository.GetByIdAsync(
            ValidFollowFollowingId,
            CancellationToken)
            .Returns(existingFollowFollowing);

        FollowReadRepository
            .GetAllAsync(Arg.Is<FollowCollectionReadQuery>(m =>
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingFollowPaginationList);
    }
}
