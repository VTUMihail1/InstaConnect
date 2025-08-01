using InstaConnect.Common.Models.Enums;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface IPostCommentLikeSortPropertyFactory
{
    IPostCommentLikeSortProperty Create(PostCommentLikeSortProperty sortProperty);
}
