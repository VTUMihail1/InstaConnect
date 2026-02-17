namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeTestRoutes
{
    public static string GetDefault(string id, string commentId)
    {
        const string Format = "api/v1/posts/{0}/comments/{1}/likes";

        return Format.FormatCurrentCulture(id, commentId);
    }

    public static string GetForUserDefault(string userId)
    {
        const string Format = "api/v1/users/{0}/post-comment-likes";

        return Format.FormatCurrentCulture(userId);
    }

    public static string GetAll(GetAllPostCommentLikesApiRequest request)
    {
        const string Format = "{0}?userName={1}&sortOrder={2}&sortTerm={3}&page={4}&pageSize={5}";

        return Format.FormatCurrentCulture(
            GetDefault(request.Id, request.CommentId),
            request.UserName,
            request.SortOrder,
            request.SortTerm,
            request.Page,
            request.PageSize);
    }

    public static string GetAllForUser(GetAllPostCommentLikesForUserApiRequest request)
    {
        const string Format = "{0}?sortOrder={1}&sortTerm={2}&page={3}&pageSize={4}";

        return Format.FormatCurrentCulture(
            GetForUserDefault(request.UserId),
            request.SortOrder,
            request.SortTerm,
            request.Page,
            request.PageSize);
    }

    public static string GetId(string id, string commentId, string userId)
    {
        const string Format = "{0}/{1}";

        return Format.FormatCurrentCulture(
            GetDefault(id, commentId),
            userId);
    }

    public static string GetCurrent(string id, string commentId)
    {
        const string Format = "{0}/current";

        return Format.FormatCurrentCulture(GetDefault(id, commentId));
    }
}
