using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Chats.Domain.Features.Users.Models.Entities;

public class User : IEntity<UserId>
{
    private User()
    {
        Id = new(string.Empty);
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = new(string.Empty);
        Name = new(string.Empty);
        Chats = [];
        ChatMessages = [];
    }

    public User(
        UserId id,
        string firstName,
        string lastName,
        Email email,
        Name name,
        Image? profileImage,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        ProfileImage = profileImage;
        Chats = [];
        ChatMessages = [];
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public User(
        UserId id,
        string firstName,
        string lastName,
        Email email,
        Name name,
        Image? profileImage,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc,
        ICollection<Chat> chats,
        ICollection<ChatMessage> chatMessages)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        ProfileImage = profileImage;
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
        Chats = chats;
        ChatMessages = chatMessages;
    }

    public UserId Id { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Email Email { get; private set; }

    public Name Name { get; private set; }

    public Image? ProfileImage { get; private set; }

    public ICollection<Chat> Chats { get; }

    public ICollection<ChatMessage> ChatMessages { get; }

    public DateTimeOffset CreatedAtUtc { get; }

    public DateTimeOffset UpdatedAtUtc { get; private set; }

    public void Update(
        Email email,
        string firstName,
        string lastName,
        Name name,
        Image? profileImage,
        DateTimeOffset updatedAtUtc)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        ProfileImage = profileImage;
        UpdatedAtUtc = updatedAtUtc;
    }

    public void AddChat(Chat chat)
    {
        Chats.Add(chat);
    }

    public void AddChatMessage(ChatMessage chatMessage)
    {
        ChatMessages.Add(chatMessage);
    }
}


