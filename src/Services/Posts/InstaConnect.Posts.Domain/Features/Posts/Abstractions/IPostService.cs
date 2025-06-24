using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IPostService
{
    public Task<PostCollection> GetAllAsync(GetAllPostsRequest request, CancellationToken cancellationToken);

    public Task<Post> GetByIdAsync(GetPostByIdRequest request, CancellationToken cancellationToken);

    public Task<Post> AddAsync(AddPostRequest request, CancellationToken cancellationToken);

    public Task<Post> UpdateAsync(UpdatePostRequest request, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostRequest request, CancellationToken cancellationToken);
}
