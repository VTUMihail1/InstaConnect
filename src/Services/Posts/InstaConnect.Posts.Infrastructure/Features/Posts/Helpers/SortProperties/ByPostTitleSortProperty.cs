using System.Linq.Expressions;

using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByPostTitleSortProperty : IPostSortProperty
{
    public PostSortProperty SortProperty => PostSortProperty.ByTitle;

    public Expression<Func<Post, object>> Property => p => p.Title;
}
