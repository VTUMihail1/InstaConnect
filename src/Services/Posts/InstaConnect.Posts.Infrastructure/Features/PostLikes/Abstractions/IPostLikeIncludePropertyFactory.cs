namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeIncludePropertyFactory
{
    IEnumerable<IPostLikeIncludeProperty> Create(ICollection<PostLikeIncludeProperty>? includeProperties);
}
