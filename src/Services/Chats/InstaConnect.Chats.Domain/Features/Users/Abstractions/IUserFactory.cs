namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IUserFactory
{
    public User Create(
        UserId id,
        string firstName,
        string lastName,
        Name name,
        Email email,
        Image? profileImage,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc);
}
