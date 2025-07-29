using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Responses;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;

public interface IPostCommentRepository
{
    Task<PostCommentCollection> GetAllAsync(GetAllPostCommentsQuery query, CancellationToken cancellationToken);

    Task<PostComment?> GetByIdAsync(string id, string commentId, CancellationToken cancellationToken);

    void Add(PostComment postComment);

    void Update(PostComment postComment);

    void Delete(PostComment postComment);
}
