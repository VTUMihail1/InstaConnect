namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
public interface IPostCommentService
{
    public Task<PostCommentCollection> GetAllAsync(GetAllPostCommentsQuery query, CancellationToken cancellationToken);

    public Task<PostComment> GetByIdAsync(GetPostCommentByIdQuery query, CancellationToken cancellationToken);

    public Task<PostComment> AddAsync(AddPostCommentCommand command, CancellationToken cancellationToken);

    public Task<PostComment> UpdateAsync(UpdatePostCommentCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostCommentCommand command, CancellationToken cancellationToken);
}
