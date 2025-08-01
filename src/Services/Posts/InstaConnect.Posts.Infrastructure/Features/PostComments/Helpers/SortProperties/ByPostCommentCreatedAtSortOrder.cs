using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortProperties;
public class ByPostCommentCreatedAtSortOrder : IPostCommentSortProperty
{
    public PostCommentSortProperty SortProperty => PostCommentSortProperty.ByCreatedAt;

    public string Property => PostCommentSortPropertyUtilities.ByCreatedAt;
}
