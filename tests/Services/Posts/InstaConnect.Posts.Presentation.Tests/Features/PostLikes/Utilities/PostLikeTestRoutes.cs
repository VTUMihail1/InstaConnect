namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeTestRoutes
{
    public static string GetDefault(string id)
    {
        const string Format = "api/v1/posts/{0}/likes";
        var route = Format.FormatCurrentCulture(id);

        return route;
    }

    public static string GetAll(GetAllPostLikesApiRequest request)
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

    public static string GetId(string id, string userId)
    {
        const string Format = "{0}/{1}";
        var route = Format.FormatCurrentCulture(
            GetDefault(id),
            userId);

        return route;
    }

    public static string GetCurrent(string id)
    {
        const string Format = "{0}/current";
        var route = Format.FormatCurrentCulture(GetDefault(id));

        return route;
    }
}
