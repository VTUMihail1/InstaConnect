namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeIncludeProperty : IIncludeProperty<PostLike>
{
    public PostLikeIncludeProperty IncludeProperty { get; }
}
