using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Responses;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
public interface IPostCommentService
{
    public Task<PostCommentCollection> GetAllAsync(GetAllPostCommentsQuery query, CancellationToken cancellationToken);

    public Task<PostComment> GetByIdAsync(GetPostCommentByIdQuery query, CancellationToken cancellationToken);

    public Task<PostComment> AddAsync(AddPostCommentCommand command, CancellationToken cancellationToken);

    public Task<PostComment> UpdateAsync(UpdatePostCommentCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostCommentCommand command, CancellationToken cancellationToken);
}
