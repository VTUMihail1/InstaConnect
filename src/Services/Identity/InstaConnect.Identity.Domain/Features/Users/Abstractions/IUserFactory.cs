using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Users.Domain.Features.Users.Abstractions;

public interface IUserFactory
{
    public User Create(
        string name,
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        string? profileImage);
}
