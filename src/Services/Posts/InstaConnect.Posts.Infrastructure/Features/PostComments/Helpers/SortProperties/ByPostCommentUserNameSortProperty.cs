using System.Linq.Expressions;

using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByPostCommentUserNameSortProperty : IPostCommentSortProperty
{
    public PostCommentSortProperty SortProperty => PostCommentSortProperty.ByUserName;

    public Expression<Func<PostComment, object>> Property => p => p.User!.Name;
}
