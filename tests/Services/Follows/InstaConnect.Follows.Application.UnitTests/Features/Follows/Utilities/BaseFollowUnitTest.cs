using AutoMapper;
using InstaConnect.Follows.Application.Features.Follows.Mappings;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Filters;
using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Domain.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Utilities;

public abstract class BaseFollowUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IFollowReadRepository FollowReadRepository { get; }

    protected IFollowWriteRepository FollowWriteRepository { get; }

    public BaseFollowUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<FollowQueryProfile>();
                    cfg.AddProfile<FollowCommandProfile>();
                })));
        CancellationToken = new CancellationToken();
        EntityPropertyValidator = new EntityPropertyValidator();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        FollowReadRepository = Substitute.For<IFollowReadRepository>();
        FollowWriteRepository = Substitute.For<IFollowWriteRepository>();
    }

    public User CreateUser()
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        return user;
    }

    public Follow CreateFollow()
    {
        var follower = CreateUser();
        var following = CreateUser();
        var follow = new Follow(follower, following);

        var followPaginationList = new PaginationList<Follow>(
            [follow],
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue,
            FollowTestUtilities.ValidTotalCountValue);

        FollowWriteRepository.GetByIdAsync(follow.Id, CancellationToken)
            .Returns(follow);

        FollowWriteRepository.GetByFollowerIdAndFollowingIdAsync(follower.Id, following.Id, CancellationToken)
            .Returns(follow);

        FollowReadRepository.GetByIdAsync(follow.Id, CancellationToken)
            .Returns(follow);

        FollowReadRepository.GetByFollowerIdAndFollowingIdAsync(follower.Id, following.Id, CancellationToken)
            .Returns(follow);

        FollowReadRepository
            .GetAllAsync(Arg.Is<FollowCollectionReadQuery>(m => m.FollowerId == follower.Id &&
                                                                 m.FollowerName == follower.UserName &&
                                                                 m.FollowingId == following.Id &&
                                                                 m.FollowingName == following.UserName &&
                                                                 m.Page == FollowTestUtilities.ValidPageValue &&
                                                                 m.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                                 m.SortOrder == FollowTestUtilities.ValidSortOrderProperty &&
                                                                 m.SortPropertyName == FollowTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(followPaginationList);

        return follow;
    }
}
