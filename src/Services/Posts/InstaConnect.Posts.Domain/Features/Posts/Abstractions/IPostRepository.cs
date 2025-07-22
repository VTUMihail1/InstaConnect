using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostRepository
{
    Task<PostCollection> GetAllAsync(GetAllPostsQuery query, CancellationToken cancellationToken);

    Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken);

    void Add(Post post);

    void Update(Post post);

    void Delete(Post post);
}
