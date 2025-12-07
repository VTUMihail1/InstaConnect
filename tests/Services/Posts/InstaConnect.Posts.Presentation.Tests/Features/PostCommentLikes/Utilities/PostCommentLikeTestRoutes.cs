namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeTestRoutes
{
    public static string GetDefault(string id, string commentId)
    {
        const string Format = "api/v1/posts/{0}/comments/{1}/likes";
        var route = Format.FormatCurrentCulture(id, commentId);

        return route;
    }

    public static string GetAll(GetAllPostCommentLikesApiRequest request)
    {
        const string Format = "{0}?userName={1}&sortOrder={2}&sortProperty={3}&page={4}&pageSize={5}";
        var route = Format.FormatCurrentCulture(
            GetDefault(request.Id, request.CommentId),
            request.UserName,
            request.SortOrder,
            request.SortProperty,
            request.Page,
            request.PageSize);

        return route;
    }

    public static string GetId(string id, string commentId, string userId)
    {
        const string Format = "{0}/{1}";
        var route = Format.FormatCurrentCulture(
            GetDefault(id, commentId),
            userId);

        return route;
    }

    public static string GetCurrent(string id, string commentId)
    {
        const string Format = "{0}/current";
        var route = Format.FormatCurrentCulture(GetDefault(id, commentId));

        return route;
    }
}
