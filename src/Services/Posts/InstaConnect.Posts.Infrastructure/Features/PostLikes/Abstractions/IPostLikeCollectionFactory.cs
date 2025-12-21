using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;
internal interface IPostLikeCollectionFactory
{
    PostLikeCollection Create(ICollection<PostLike> postLikes, int totalCount, CommonPaginationQuery pagination);
}
