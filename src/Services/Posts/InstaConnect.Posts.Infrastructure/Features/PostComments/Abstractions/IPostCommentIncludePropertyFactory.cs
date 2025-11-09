namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentIncludePropertyFactory
{
    IEnumerable<IPostCommentIncludeProperty> Create(ICollection<PostCommentIncludeProperty>? includeProperties);
}
