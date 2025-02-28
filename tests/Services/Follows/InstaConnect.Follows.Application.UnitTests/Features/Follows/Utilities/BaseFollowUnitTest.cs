﻿using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Helpers;
using InstaConnect.Follows.Application.Extensions;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Filters;
using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Utilities;

public abstract class BaseFollowUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected IFollowFactory FollowFactory { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IFollowReadRepository FollowReadRepository { get; }

    protected IFollowWriteRepository FollowWriteRepository { get; }

    protected BaseFollowUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        FollowFactory = Substitute.For<IFollowFactory>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(ApplicationReference.Assembly))));
        CancellationToken = new CancellationToken();
        EntityPropertyValidator = new EntityPropertyValidator();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        FollowReadRepository = Substitute.For<IFollowReadRepository>();
        FollowWriteRepository = Substitute.For<IFollowWriteRepository>();
    }

    private User CreateUserUtil()
    {
        var user = UserTestUtilities.CreateUser();

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        return user;
    }

    protected User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }

    public Follow CreateFollowUtil(User follower, User following)
    {
        var follow = FollowTestUtilities.CreateFollow(follower, following);

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

    public Follow CreateFollow()
    {
        var follower = CreateUser();
        var following = CreateUser();
        var follow = CreateFollowUtil(follower, following);

        return follow;
    }

    public Follow CreateFollowFactory()
    {
        var follower = CreateUser();
        var following = CreateUser();

        var follow = FollowTestUtilities.CreateFollow(follower, following);

        FollowFactory.Get(follower.Id, following.Id)
            .Returns(follow);

        return follow;
    }
}
