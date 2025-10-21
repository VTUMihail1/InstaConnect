using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IPostCommentIncludePropertyFactory
{
    ICollection<IPostCommentIncludeProperty> Create(ICollection<PostCommentIncludeProperty>? includeProperties);
}
