using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

internal interface IPostCommentFactory
{
    public PostComment Get(string postId, string userId, string content);
}
