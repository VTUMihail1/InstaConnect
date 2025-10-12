using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
internal interface IPostCollectionFactory
{
    PostCollection Create(ICollection<Post> posts, long totalCount, PostPaginationQuery pagination);
}
