using AutoMapper;
using InstaConnect.Posts.Application.Extensions;
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
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Common.Helpers;
using InstaConnect.Shared.Common.Utilities;
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

    protected BasePostCommentUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(ApplicationReference.Assembly))));
        EntityPropertyValidator = new EntityPropertyValidator();
        CancellationToken = new CancellationToken();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostCommentReadRepository = Substitute.For<IPostCommentReadRepository>();
        PostCommentWriteRepository = Substitute.For<IPostCommentWriteRepository>();
    }

    private User CreateUserUtil()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        return user;
    }

    protected User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }

    private Post CreatePostUtil(User user)
    {
        var post = new Post(
            SharedTestUtilities.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            SharedTestUtilities.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
            user);

        PostWriteRepository.GetByIdAsync(
            post.Id,
            CancellationToken)
            .Returns(post);

        return post;
    }

    protected Post CreatePost()
    {
        var user = CreateUser();
        var post = CreatePostUtil(user);

        return post;
    }

    private PostComment CreatePostCommentUtil(User user, Post post)
    {
        var postComment = new PostComment(
            user,
            post,
            SharedTestUtilities.GetAverageString(PostCommentConfigurations.ContentMaxLength, PostCommentConfigurations.ContentMinLength));

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
                                                                        m.UserName == user.UserName &&
                                                                        m.PostId == post.Id &&
                                                                        m.Page == PostCommentTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostCommentTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostCommentTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postCommentPaginationList);

        return postComment;
    }

    protected PostComment CreatePostComment()
    {
        var user = CreateUser();
        var post = CreatePost();
        var postComment = CreatePostCommentUtil(user, post);

        return postComment;
    }
}
