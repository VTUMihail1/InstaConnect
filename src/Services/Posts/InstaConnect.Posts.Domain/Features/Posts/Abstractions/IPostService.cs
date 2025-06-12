using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IPostService
{
    public Task<PostQueryCollection> GetAllAsync(PostQueryParameters parameters, CancellationToken cancellationToken);

    public Task<Post> GetByIdAsync(string id, CancellationToken cancellationToken);

    public Task<Post> AddAsync(string userId, string title, string content, CancellationToken cancellationToken);

    public Task<Post> UpdateAsync(string id, string userId, string title, string content, CancellationToken cancellationToken);

    public Task DeleteAsync(string id, string userId, CancellationToken cancellationToken);
}
