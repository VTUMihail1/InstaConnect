namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
public static class PostCommentTestRoutes
{
    public static string GetDefault(string id)
    {
        const string Format = "api/v1/posts/{0}/comments";

        return Format.FormatCurrentCulture(id);
    }

    public static string GetForUserDefault(string userId)
    {
        const string Format = "api/v1/users/{0}/post-comments";

        return Format.FormatCurrentCulture(userId);
    }

    public static string GetAll(GetAllPostCommentsApiRequest request)
    {
        const string Format = "{0}?userName={1}&sortOrder={2}&sortProperty={3}&page={4}&pageSize={5}";

        return Format.FormatCurrentCulture(
            GetDefault(request.Id),
            request.UserName,
            request.SortOrder,
            request.SortTerm,
            request.Page,
            request.PageSize);
    }

    public static string GetAllForUser(GetAllPostCommentsForUserApiRequest request)
    {
        const string Format = "{0}?sortOrder={1}&sortProperty={2}&page={3}&pageSize={4}";

        return Format.FormatCurrentCulture(
            GetForUserDefault(request.UserId),
            request.SortOrder,
            request.SortTerm,
            request.Page,
            request.PageSize);
    }

    public static string GetId(string id, string commentId)
    {
        const string Format = "{0}/{1}";

        return Format.FormatCurrentCulture(
            GetDefault(id),
            commentId);
    }
}
