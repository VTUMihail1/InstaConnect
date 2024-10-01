using AutoMapper;
using InstaConnect.Follows.Business.Features.Follows.Mappings;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
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

        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        FollowReadRepository = Substitute.For<IFollowReadRepository>();
        FollowWriteRepository = Substitute.For<IFollowWriteRepository>();

        var existingFollower = new User(
            FollowTestUtilities.ValidUserFirstName,
            FollowTestUtilities.ValidUserLastName,
            FollowTestUtilities.ValidUserEmail,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidUserProfileImage)
        {
            Id = FollowTestUtilities.ValidCurrentUserId,
        };

        var existingFollowFollower = new User(
            FollowTestUtilities.ValidUserFirstName,
            FollowTestUtilities.ValidUserLastName,
            FollowTestUtilities.ValidUserEmail,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidUserProfileImage)
        {
            Id = FollowTestUtilities.ValidFollowCurrentUserId,
        };

        var existingFollowing = new User(
            FollowTestUtilities.ValidUserFirstName,
            FollowTestUtilities.ValidUserLastName,
            FollowTestUtilities.ValidUserEmail,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidUserProfileImage)
        {
            Id = FollowTestUtilities.ValidFollowingId
        };

        var existingFollowFollowing = new User(
            FollowTestUtilities.ValidUserFirstName,
            FollowTestUtilities.ValidUserLastName,
            FollowTestUtilities.ValidUserEmail,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidUserProfileImage)
        {
            Id = FollowTestUtilities.ValidFollowFollowingId
        };

        var existingFollow = new Follow(
            FollowTestUtilities.ValidFollowCurrentUserId,
            FollowTestUtilities.ValidFollowFollowingId)
        {
            Id = FollowTestUtilities.ValidId,
            Follower = existingFollowFollower,
            Following = existingFollowFollowing
        };

        var existingFollowPaginationList = new PaginationList<Follow>(
            [existingFollow],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue);

        FollowReadRepository.GetByIdAsync(
            FollowTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingFollow);

        FollowWriteRepository.GetByIdAsync(
            FollowTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingFollow);

        FollowReadRepository.GetByFollowerIdAndFollowingIdAsync(
            FollowTestUtilities.ValidFollowCurrentUserId,
            FollowTestUtilities.ValidFollowFollowingId,
            CancellationToken)
            .Returns(existingFollow);

        FollowWriteRepository.GetByFollowerIdAndFollowingIdAsync(
            FollowTestUtilities.ValidFollowCurrentUserId,
            FollowTestUtilities.ValidFollowFollowingId,
            CancellationToken)
            .Returns(existingFollow);

        UserWriteRepository.GetByIdAsync(
            FollowTestUtilities.ValidCurrentUserId,
            CancellationToken)
            .Returns(existingFollower);

        UserWriteRepository.GetByIdAsync(
            FollowTestUtilities.ValidFollowingId,
            CancellationToken)
            .Returns(existingFollowing);

        UserWriteRepository.GetByIdAsync(
            FollowTestUtilities.ValidFollowCurrentUserId,
            CancellationToken)
            .Returns(existingFollowFollower);

        UserWriteRepository.GetByIdAsync(
            FollowTestUtilities.ValidFollowFollowingId,
            CancellationToken)
            .Returns(existingFollowFollowing);

        FollowReadRepository
            .GetAllAsync(Arg.Is<FollowCollectionReadQuery>(m => m.FollowerId == FollowTestUtilities.ValidFollowCurrentUserId &&
                                                                 m.FollowingId == FollowTestUtilities.ValidFollowFollowingId &&
                                                                 m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                                 m.Page == ValidPageValue &&
                                                                 m.PageSize == ValidPageSizeValue &&
                                                                 m.SortOrder == ValidSortOrderProperty &&
                                                                 m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingFollowPaginationList);
    }
}
