using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
    public static void ShouldSatisfy(
        this AddPostCommentCommandResponse response,
        PostComment postComment,
        AddPostCommentCommandRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, request));
    }

    public static void ShouldSatisfy(
        this UpdatePostCommentCommandResponse response,
        PostComment postComment,
        UpdatePostCommentCommandRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, request));
    }

    public static void ShouldSatisfy(
        this GetPostCommentByIdQueryResponse response,
        PostComment postComment,
        GetPostCommentByIdQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentsQueryResponse response,
        Post post,
        ICollection<PostComment> postComments,
        GetAllPostCommentsQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(post, postComments, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentsQueryResponse response,
        Post post,
        ICollection<PostComment> postComments,
        GetAllPostCommentsQueryRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(post, postComments, request, termTransformer));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentsForUserQueryResponse response,
        User user,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(user, postComments, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentsForUserQueryResponse response,
        User user,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserQueryRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(user, postComments, request, termTransformer));
    }

    public static void ShouldSatisfy(this PostComment postComment, AddPostCommentCommandRequest request)
    {
        postComment.ShouldSatisfy(p => p.Matches(request));
    }

    public static void ShouldSatisfy(this PostComment postComment, UpdatePostCommentCommandRequest request)
    {
        postComment.ShouldSatisfy(p => p.Matches(request));
    }
}
