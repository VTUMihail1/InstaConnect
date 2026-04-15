namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeCommandService
{
    public Task<PostLikeId> AddAsync(AddPostLikeCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostLikeCommand command, CancellationToken cancellationToken);
}
