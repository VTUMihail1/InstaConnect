using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
internal interface IPostCommentCollectionFactory
{
    PostCommentCollection Create(ICollection<PostComment> postComments, int totalCount, CommonPaginationQuery pagination);
}
