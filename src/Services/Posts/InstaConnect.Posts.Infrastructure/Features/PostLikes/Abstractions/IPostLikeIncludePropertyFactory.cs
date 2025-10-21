using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IPostLikeIncludePropertyFactory
{
    ICollection<IPostLikeIncludeProperty> Create(ICollection<PostLikeIncludeProperty>? includeProperties);
}
