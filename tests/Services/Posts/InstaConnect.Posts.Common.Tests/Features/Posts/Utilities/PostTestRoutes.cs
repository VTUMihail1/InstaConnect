using System.Globalization;

using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
public static class PostTestRoutes
{
    public static string GetDefault()
    {
        const string Route = "api/v1/posts";

        return Route;
    }

    public static string GetAll(GetAllPostsApiRequest request)
    {
        const string Format = "api/v1/posts?&userId={0}&userName={1}&title={2}&sortOrder={3}&sortProperty={4}&page={5}&pageSize={6}";
        var route = Format.FormatInvariant(
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
        const string Format = "api/v1/posts/{0}";
        var route = Format.FormatInvariant(id);

        return route;
    }
}
