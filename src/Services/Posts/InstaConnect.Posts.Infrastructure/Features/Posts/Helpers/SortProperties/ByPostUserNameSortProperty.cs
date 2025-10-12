using System.Linq.Expressions;

using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByPostUserNameSortProperty : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByUserName;

    public Expression<Func<Post, object>> Property => p => p.User!.Name;
}
