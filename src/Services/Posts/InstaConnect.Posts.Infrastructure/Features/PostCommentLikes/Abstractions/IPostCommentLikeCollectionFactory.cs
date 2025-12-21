using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
internal interface IPostCommentLikeCollectionFactory
{
    PostCommentLikeCollection Create(ICollection<PostCommentLike> entities, int totalCount, CommonPaginationQuery pagination);
}
