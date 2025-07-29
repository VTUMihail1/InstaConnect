using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IUserFactory
{
    public User Create(
        string id,
        string firstName,
        string lastName,
        string name,
        string email,
        string? profileImage);
}
