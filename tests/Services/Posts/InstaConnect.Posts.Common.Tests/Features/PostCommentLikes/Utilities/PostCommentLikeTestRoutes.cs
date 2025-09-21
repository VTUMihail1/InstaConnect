using System.Globalization;

using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeTestRoutes
{
    public static string GetDefault(string id, string commentId)
    {
        const string Format = "api/v1/posts/{0}/comments{1}/likes";
        var route = Format.FormatInvariantCulture(id, commentId);

        return route;
    }

    public static string GetAll(GetAllPostCommentLikesApiRequest request)
    {
        const string Format = "{0}?&userId={1}&userName={2}&sortOrder={3}&sortProperty={4}&page={5}&pageSize={6}";
        var route = Format.FormatInvariantCulture(
            GetDefault(request.Filter.Id, request.Filter.CommentId),
            request.Filter.UserName,
            request.Sorting.Order,
            request.Sorting.Property,
            request.Pagination.Page,
            request.Pagination.PageSize);

        return route;
    }

    public static string GetId(string id, string commentId, string userId)
    {
        const string Format = "{0}/{1}";
        var route = Format.FormatInvariantCulture(
            GetDefault(id, commentId),
            userId);

        return route;
    }

    public static string GetCurrent(string id, string commentId)
    {
        const string Format = "{0}/current";
        var route = Format.FormatInvariantCulture(GetDefault(id, commentId));

        return route;
    }
}
