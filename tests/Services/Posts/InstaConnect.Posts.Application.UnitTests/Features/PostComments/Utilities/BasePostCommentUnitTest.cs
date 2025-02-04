using AutoMapper;
using InstaConnect.Posts.Application.Features.PostComments.Mappings;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Abstract;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Application.UnitTests.Utilities;
using InstaConnect.Shared.Domain.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Utilities;

public abstract class BasePostCommentUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected IPostCommentReadRepository PostCommentReadRepository { get; }

    protected IPostCommentWriteRepository PostCommentWriteRepository { get; }

    public BasePostCommentUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommentQueryProfile>();
                    cfg.AddProfile<PostCommentCommandProfile>();
                })));
        EntityPropertyValidator = new EntityPropertyValidator();
        CancellationToken = new CancellationToken();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostCommentReadRepository = Substitute.For<IPostCommentReadRepository>();
        PostCommentWriteRepository = Substitute.For<IPostCommentWriteRepository>();
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

    public Post CreatePost()
    {
        var user = CreateUser();
        var post = new Post(
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent,
            user);

        PostWriteRepository.GetByIdAsync(post.Id, CancellationToken)
            .Returns(post);

        return post;
    }

    public PostComment CreatePostComment()
    {
        var user = CreateUser();
        var post = CreatePost();
        var postComment = new PostComment(user, post, PostCommentTestUtilities.ValidContent);

        var postCommentPaginationList = new PaginationList<PostComment>(
        [postComment],
        PostCommentTestUtilities.ValidPageValue,
        PostCommentTestUtilities.ValidPageSizeValue,
        PostCommentTestUtilities.ValidTotalCountValue);

        PostCommentWriteRepository.GetByIdAsync(postComment.Id, CancellationToken)
            .Returns(postComment);

        PostCommentReadRepository.GetByIdAsync(postComment.Id, CancellationToken)
            .Returns(postComment);

        PostCommentReadRepository
            .GetAllAsync(Arg.Is<PostCommentCollectionReadQuery>(m =>
                                                                        m.UserId == user.Id &&
                                                                        m.UserName == UserTestUtilities.ValidName &&
                                                                        m.PostId == post.Id &&
                                                                        m.Page == PostCommentTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostCommentTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostCommentTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postCommentPaginationList);

        return postComment;
    }
}
