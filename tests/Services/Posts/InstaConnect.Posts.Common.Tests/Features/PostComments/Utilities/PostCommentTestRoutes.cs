using System.Globalization;

using InstaConnect.Common.Extensions;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
public static class PostCommentTestRoutes
{
    public static string GetDefault(string id)
    {
        const string Format = "api/v1/posts/{0}/comments";
        var route = Format.FormatInvariantCulture(id);

        return route;
    }

    public static string GetAll(GetAllPostCommentsApiRequest request)
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

    public static string GetId(string id, string commentId)
    {
        const string Format = "{0}/{1}";
        var route = Format.FormatInvariantCulture(
            GetDefault(id),
            commentId);

        return route;
    }
}
