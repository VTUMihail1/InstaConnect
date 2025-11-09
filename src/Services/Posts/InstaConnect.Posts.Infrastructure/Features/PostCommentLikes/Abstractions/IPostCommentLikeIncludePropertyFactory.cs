namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeIncludePropertyFactory
{
    IEnumerable<IPostCommentLikeIncludeProperty> Create(ICollection<PostCommentLikeIncludeProperty>? includeProperties);
}
