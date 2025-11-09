namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentIncludeProperty : IIncludeProperty<PostComment>
{
    public PostCommentIncludeProperty IncludeProperty { get; }
}
