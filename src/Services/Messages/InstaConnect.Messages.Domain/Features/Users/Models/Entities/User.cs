using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;

namespace InstaConnect.Messages.Domain.Features.Users.Models.Entities;

public class User : IBaseEntity, IAuditableInfo
{
    private User()
    {
        Id = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        UserName = string.Empty;
        SenderMessages = [];
        ReceiverMessages = [];
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string userName,
        string? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        ProfileImage = profileImage;
        SenderMessages = [];
        ReceiverMessages = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string userName,
        string? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt,
        ICollection<Message> senderMessages,
        ICollection<Message> receiverMessages)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        SenderMessages = senderMessages;
        ReceiverMessages = receiverMessages;
    }

    public string Id { get; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public string? ProfileImage { get; set; }

    public ICollection<Message> SenderMessages { get; }

    public ICollection<Message> ReceiverMessages { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }
}


