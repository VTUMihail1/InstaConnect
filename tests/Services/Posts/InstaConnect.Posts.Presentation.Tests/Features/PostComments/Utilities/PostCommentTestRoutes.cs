namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
public static class PostCommentTestRoutes
{
    public static string GetDefault(string id)
    {
        const string Format = "api/v1/posts/{0}/comments";
        var route = Format.FormatCurrentCulture(id);

        return route;
    }

    public static string GetAll(GetAllPostCommentsApiRequest request)
    {
        const string Format = "{0}?userName={1}&sortOrder={2}&sortProperty={3}&page={4}&pageSize={5}";
        var route = Format.FormatCurrentCulture(
            GetDefault(request.Id),
            request.UserName,
            request.SortOrder,
            request.SortProperty,
            request.Page,
            request.PageSize);

        return route;
    }

    public static string GetId(string id, string commentId)
    {
        const string Format = "{0}/{1}";
        var route = Format.FormatCurrentCulture(
            GetDefault(id),
            commentId);

        return route;
    }
}
