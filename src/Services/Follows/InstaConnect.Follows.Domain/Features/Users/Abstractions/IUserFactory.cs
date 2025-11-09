namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

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
