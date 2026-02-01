namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
public interface IPostCommentCommandService
{
    public Task<PostCommentId> AddAsync(AddPostCommentCommand command, CancellationToken cancellationToken);

    public Task<PostCommentId> UpdateAsync(UpdatePostCommentCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostCommentCommand command, CancellationToken cancellationToken);
}
