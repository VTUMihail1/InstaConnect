namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

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
