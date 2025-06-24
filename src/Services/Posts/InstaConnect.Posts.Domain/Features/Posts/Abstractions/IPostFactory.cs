using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostFactory
{
    public Post Create(string userId, string title, string content);
}
