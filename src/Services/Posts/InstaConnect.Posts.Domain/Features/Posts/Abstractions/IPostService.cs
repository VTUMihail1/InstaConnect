using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IPostService
{
    public Task<PostCollection> GetAllAsync(GetAllPostsQuery query, CancellationToken cancellationToken);

    public Task<Post> GetByIdAsync(GetPostByIdQuery query, CancellationToken cancellationToken);

    public Task<Post> AddAsync(AddPostCommand command, CancellationToken cancellationToken);

    public Task<Post> UpdateAsync(UpdatePostCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostCommand command, CancellationToken cancellationToken);
}
