namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostCommandService
{
	public Task<PostId> AddAsync(AddPostCommand command, CancellationToken cancellationToken);

	public Task<PostId> UpdateAsync(UpdatePostCommand command, CancellationToken cancellationToken);

	public Task DeleteAsync(DeletePostCommand command, CancellationToken cancellationToken);
}
