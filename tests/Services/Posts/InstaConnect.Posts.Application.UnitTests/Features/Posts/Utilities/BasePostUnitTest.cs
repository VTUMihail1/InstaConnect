using AutoMapper;
using InstaConnect.Posts.Application.Features.Posts.Mappings;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Posts.Models.Filters;
using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Application.UnitTests.Utilities;
using InstaConnect.Shared.Domain.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;

public abstract class BasePostUnitTest : BaseSharedUnitTest
{
    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    public BasePostUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostQueryProfile>();
                    cfg.AddProfile<PostCommandProfile>();
                }))),
        new EntityPropertyValidator())
    {
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();

        var existingUser = new User(
            PostTestUtilities.ValidUserFirstName,
            PostTestUtilities.ValidUserLastName,
            PostTestUtilities.ValidUserEmail,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidUserProfileImage)
        {
            Id = PostTestUtilities.ValidCurrentUserId,
        };

        var existingPostUser = new User(
            PostTestUtilities.ValidUserFirstName,
            PostTestUtilities.ValidUserLastName,
            PostTestUtilities.ValidUserEmail,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidUserProfileImage)
        {
            Id = PostTestUtilities.ValidPostCurrentUserId,
        };

        var existingPost = new Post(
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent,
            PostTestUtilities.ValidPostCurrentUserId)
        {
            Id = PostTestUtilities.ValidId,
            User = existingPostUser,
        };

        var existingPostPaginationList = new PaginationList<Post>(
            [existingPost],
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue,
            PostTestUtilities.ValidTotalCountValue);

        PostReadRepository.GetByIdAsync(
            PostTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingPost);

        PostWriteRepository.GetByIdAsync(
            PostTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingPost);

        UserWriteRepository.GetByIdAsync(
            PostTestUtilities.ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(
            PostTestUtilities.ValidPostCurrentUserId,
            CancellationToken)
            .Returns(existingPostUser);

        PostReadRepository
            .GetAllAsync(Arg.Is<PostCollectionReadQuery>(m =>
                                                                        m.Title == PostTestUtilities.ValidTitle &&
                                                                        m.UserId == PostTestUtilities.ValidPostCurrentUserId &&
                                                                        m.UserName == PostTestUtilities.ValidUserName &&
                                                                        m.Page == PostTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(existingPostPaginationList);
    }
}
