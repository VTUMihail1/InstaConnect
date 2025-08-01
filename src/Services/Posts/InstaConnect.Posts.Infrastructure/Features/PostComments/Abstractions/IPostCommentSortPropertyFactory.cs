using InstaConnect.Common.Models.Enums;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface IPostCommentSortPropertyFactory
{
    IPostCommentSortProperty Create(PostCommentSortProperty sortProperty);
}
