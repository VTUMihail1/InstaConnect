using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortProperties;
public class ByPostCommentLikeCreatedAtSortOrder : IPostCommentLikeSortProperty
{
    public PostCommentLikeSortProperty SortProperty => PostCommentLikeSortProperty.ByCreatedAt;

    public string Property => PostCommentLikeSortPropertyUtilities.ByCreatedAt;
}
