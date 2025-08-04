using System.Globalization;

using InstaConnect.Common.Extensions;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
public static class PostLikeTestRoutes
{
    public static string GetDefault(string id)
    {
        const string Format = "api/v1/posts/{0}/likes";
        var route = Format.FormatInvariantCulture(id);

        return route;
    }

    public static string GetAll(GetAllPostLikesApiRequest request)
    {
        const string Format = "{0}?&userId={1}&userName={2}&sortOrder={3}&sortProperty={4}&page={5}&pageSize={6}";
        var route = Format.FormatInvariantCulture(
            GetDefault(request.Filter.Id),
            request.Filter.UserId,
            request.Filter.UserName,
            request.Sorting.Order,
            request.Sorting.Property,
            request.Pagination.Page,
            request.Pagination.PageSize);

        return route;
    }

    public static string GetId(string id, string likeId)
    {
        const string Format = "{0}/{1}";
        var route = Format.FormatInvariantCulture(
            GetDefault(id),
            likeId);

        return route;
    }
}
