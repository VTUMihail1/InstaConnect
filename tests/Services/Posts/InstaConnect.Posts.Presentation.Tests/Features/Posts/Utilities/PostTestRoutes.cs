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
        const string Format = "{0}?&userId={1}&userName={2}&title={3}&sortOrder={4}&sortProperty={5}&page={6}&pageSize={7}";
        var route = Format.FormatCurrentCulture(
            GetDefault(),
            request.Filter.UserId,
            request.Filter.UserName,
            request.Filter.Title,
            request.Sorting.Order,
            request.Sorting.Property,
            request.Pagination.Page,
            request.Pagination.PageSize);

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
