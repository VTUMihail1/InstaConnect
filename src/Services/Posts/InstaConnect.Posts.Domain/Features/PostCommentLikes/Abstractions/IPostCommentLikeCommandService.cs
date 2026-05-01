namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeCommandService
{
	public Task<PostCommentLikeId> AddAsync(AddPostCommentLikeCommand command, CancellationToken cancellationToken);

	public Task DeleteAsync(DeletePostCommentLikeCommand command, CancellationToken cancellationToken);
}
