using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers;

internal class PostCollectionFactory : IPostCollectionFactory
{
    public PostCollection Create(ICollection<Post> posts, int totalCount, PostPaginationRequest pagination)
    {
        var hasNextPage = pagination.Page * pagination.PageSize < totalCount;
        var hasPreviousPage = pagination.Page > 1;

        return new PostCollection(posts, pagination.Page, pagination.PageSize, totalCount, hasNextPage, hasPreviousPage);
    }
}
