using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IPostService
{
    public void Update(Post post, string title, string content);
}
