using System.Linq.Expressions;

using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeSortProperty
{
    public PostLikeSortProperty SortProperty { get; }

    public Expression<Func<PostLike, object>> Property { get; }
}
