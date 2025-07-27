using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
public interface IPostLikeService
{
    public Task<PostLikeCollection> GetAllAsync(GetAllPostLikesQuery query, CancellationToken cancellationToken);

    public Task<PostLike> GetByIdAsync(GetPostLikeByIdQuery query, CancellationToken cancellationToken);

    public Task<PostLike> AddAsync(AddPostLikeCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostLikeCommand command, CancellationToken cancellationToken);
}
