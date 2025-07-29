using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;

public interface IPostCommentFactory
{
    public PostComment Create(string id, string userId, string content);
}
