using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
internal interface IPostCollectionFactory
{
    PostCollection Create(ICollection<Post> posts, int totalCount, CommonPaginationQuery pagination);
}
