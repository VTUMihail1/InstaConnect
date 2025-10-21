using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;
internal interface IPostLikeCollectionFactory
{
    PostLikeCollection Create(ICollection<PostLike> postLikes, int totalCount, PostLikePaginationQuery pagination);
}
