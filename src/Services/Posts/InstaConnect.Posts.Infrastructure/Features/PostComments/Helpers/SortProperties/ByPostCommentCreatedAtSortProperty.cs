using System.Linq.Expressions;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class ByPostCommentCreatedAtSortProperty : IPostCommentSortProperty
{
    public PostCommentSortProperty SortProperty => PostCommentSortProperty.ByCreatedAt;

    public Expression<Func<PostComment, object>> Property => p => p.CreatedAt;
}
