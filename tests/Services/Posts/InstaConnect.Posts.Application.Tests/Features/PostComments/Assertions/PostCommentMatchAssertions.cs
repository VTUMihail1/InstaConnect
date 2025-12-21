using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommentCommandResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Matches(postComment));
    }

    public static void ShouldSatisfy(this UpdatePostCommentCommandResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Matches(postComment));
    }

    public static void ShouldSatisfy(this GetPostCommentByIdQueryResponse response, PostComment postComment)
    {
        response.ShouldSatisfy(p => p.Matches(postComment));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentsQueryResponse response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsQueryRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComments, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentsQueryResponse response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsQueryRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(postComments, request, termTransformer));
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
