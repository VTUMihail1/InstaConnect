using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.SortProperties;

public class ByPostCommentLikeUserNameSortOrder : IPostCommentLikeSortProperty
{
    public PostCommentLikeSortProperty SortProperty => PostCommentLikeSortProperty.ByUserName;

    public string Property => PostCommentLikeSortPropertyUtilities.ByUserName;
}
