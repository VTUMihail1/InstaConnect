using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostFactory
{
    public Post Get(string userId, string title, string content);
}
