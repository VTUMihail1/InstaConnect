using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
    public static void ShouldSatisfy(
        this AddPostCommentApiResponse response,
        PostComment postComment,
        AddPostCommentApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, request));
    }

    public static void ShouldSatisfy(
        this UpdatePostCommentApiResponse response,
        PostComment postComment,
        UpdatePostCommentApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, request));
    }

    public static void ShouldSatisfy(
        this GetPostCommentByIdApiResponse response,
        PostComment postComment,
        GetPostCommentByIdApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComment, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentsApiResponse response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComments, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentsApiResponse response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsApiRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(postComments, request, termTransformer));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentsForUserApiResponse response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserApiRequest request)
    {
        response.ShouldSatisfy(p => p.Matches(postComments, request));
    }

    public static void ShouldSatisfy(
        this GetAllPostCommentsForUserApiResponse response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserApiRequest request,
        ISortEnumTermTransformer<PostComment> termTransformer)
    {
        response.ShouldSatisfy(p => p.Matches(postComments, request, termTransformer));
    }

    public static void ShouldSatisfy(
        this ActionResult<AddPostCommentApiResponse> response,
        PostComment postComment,
        AddPostCommentApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment, request));
    }

    public static void ShouldSatisfy(
        this ActionResult<UpdatePostCommentApiResponse> response,
        PostComment postComment,
        UpdatePostCommentApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment, request));
    }

    public static void ShouldSatisfy(
        this ActionResult<GetPostCommentByIdApiResponse> response,
        PostComment postComment,
        GetPostCommentByIdApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment, request));
    }

    public static void ShouldSatisfy(
        this ActionResult<GetAllPostCommentsApiResponse> response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComments, request));
    }

    public static void ShouldSatisfy(
        this ActionResult<GetAllPostCommentsForUserApiResponse> response,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComments, request));
    }

    public static void ShouldSatisfy(this PostComment postComment, AddPostCommentApiRequest request)
    {
        postComment.ShouldSatisfy(p => p.Matches(request));
    }

    public static void ShouldSatisfy(this PostComment postComment, UpdatePostCommentApiRequest request)
    {
        postComment.ShouldSatisfy(p => p.Matches(request));
    }
}
