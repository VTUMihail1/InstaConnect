namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
public static class PostTestRoutes
{
    public static string GetDefault()
    {
        const string Route = "api/v1/posts";

        return Route;
    }

    public static string GetAll(GetAllPostsApiRequest request)
    {
        const string Format = "{0}?userName={1}&title={2}&sortOrder={3}&sortProperty={4}&page={5}&pageSize={6}";
        var route = Format.FormatCurrentCulture(
            GetDefault(),
            request.UserName,
            request.Title,
            request.SortOrder,
            request.SortProperty,
            request.Page,
            request.PageSize);

        return route;
    }

    public static string GetId(string id)
    {
        const string Format = "{0}/{1}";
        var route = Format.FormatCurrentCulture(
            GetDefault(),
            id);

        return route;
    }
}
