using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentIncludeProperty : IIncludeProperty<PostComment>
{
    public PostCommentIncludeProperty IncludeProperty { get; }
}
