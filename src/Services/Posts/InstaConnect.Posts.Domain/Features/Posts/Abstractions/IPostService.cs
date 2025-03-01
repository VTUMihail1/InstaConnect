using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IPostService
{
    public void Update(Post post, string title, string content);
}
