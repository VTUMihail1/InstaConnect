using AutoMapper;
using InstaConnect.Posts.Business.Features.Posts.Mappings;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Models.Filters;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.Posts.Utilities;

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
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue);

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
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingPostPaginationList);
    }
}
