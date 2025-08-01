using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.SortProperties;

public class ByPostCommentUserNameSortOrder : IPostCommentSortProperty
{
    public PostCommentSortProperty SortProperty => PostCommentSortProperty.ByUserName;

    public string Property => PostCommentSortPropertyUtilities.ByUserName;
}
