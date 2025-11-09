namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostIncludeProperty : IIncludeProperty<Post>
{
    public PostIncludeProperty IncludeProperty { get; }
}
