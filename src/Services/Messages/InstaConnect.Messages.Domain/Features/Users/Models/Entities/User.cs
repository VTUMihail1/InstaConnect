using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Domain.Features.Users.Models.Entities;

public class User : IEntity
{
    private readonly IList<Chat> _chats;
    private readonly IList<ChatMessage> _chatMessages;

    private User()
    {
        Id = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Name = string.Empty;
        _chats = [];
        _chatMessages = [];
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string name,
        string? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        ProfileImage = profileImage;
        _chats = [];
        _chatMessages = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string name,
        string? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt,
        IList<Chat> chats,
        IList<ChatMessage> chatMessages)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        _chats = chats;
        _chatMessages = chatMessages;
    }

    public string Id { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Name { get; private set; }

    public string? ProfileImage { get; private set; }

    public IReadOnlyCollection<Chat> Chats => _chats.AsReadOnly();

    public IReadOnlyCollection<ChatMessage> ChatMessages => _chatMessages.AsReadOnly();

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(
        string email,
        string firstName,
        string lastName,
        string name,
        string? profileImage,
        DateTimeOffset updatedAt)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        ProfileImage = profileImage;
        UpdatedAt = updatedAt;
    }

    public bool HasEmail(string email)
    {
        var hasEmail = Email.EqualsOrdinalIgnoreCase(email);

        return hasEmail;
    }

    public bool DoesNotHaveEmail(string email)
    {
        var hasEmail = !HasEmail(email);

        return hasEmail;
    }

    public bool HasName(string name)
    {
        var hasName = Name.EqualsOrdinalIgnoreCase(name);

        return hasName;
    }

    public bool DoesNotHaveName(string name)
    {
        var hasName = !HasName(name);

        return hasName;
    }

    public void AddChat(Chat chat)
    {
        _chats.Add(chat);
    }

    public void AddChatMessage(ChatMessage chatMessage)
    {
        _chatMessages.Add(chatMessage);
    }
}


