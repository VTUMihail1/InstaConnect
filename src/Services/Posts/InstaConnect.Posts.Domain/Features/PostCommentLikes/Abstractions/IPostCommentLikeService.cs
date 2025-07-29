using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;
public interface IPostCommentLikeService
{
    public Task<PostCommentLikeCollection> GetAllAsync(GetAllPostCommentLikesQuery query, CancellationToken cancellationToken);

    public Task<PostCommentLike> GetByIdAsync(GetPostCommentLikeByIdQuery query, CancellationToken cancellationToken);

    public Task<PostCommentLike> AddAsync(AddPostCommentLikeCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostCommentLikeCommand command, CancellationToken cancellationToken);
}
