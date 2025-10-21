using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Responses;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;
internal interface IPostCommentCollectionFactory
{
    PostCommentCollection Create(ICollection<PostComment> postComments, int totalCount, PostCommentPaginationQuery pagination);
}
