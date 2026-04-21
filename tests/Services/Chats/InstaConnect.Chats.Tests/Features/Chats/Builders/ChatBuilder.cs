using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Tests.Features.Chats.Builders;

public class ChatBuilder
{
    private string _participantOneId;
    private string _participantTwoId;
    private User _participantOne;
    private User _participantTwo;
    private DateTimeOffset _createdAtUtc;

    public ChatBuilder(User participantOne, User participantTwo)
    {
        _participantOneId = participantOne.Id.Id;
        _participantTwoId = participantTwo.Id.Id;
        _participantOne = participantOne;
        _participantTwo = participantTwo;
        _createdAtUtc = ChatDataFaker.GetCreatedAtUtc();
    }

    public Chat Build()
    {
        var chat = new Chat(
                new(
                    new(_participantOneId),
                    new(_participantTwoId)),
                _createdAtUtc);

        chat.AddParticipantOne(_participantOne);
        chat.AddParticipantTwo(_participantTwo);
        _participantOne.AddChat(chat);
        _participantTwo.AddChat(chat);

        return chat;
    }
}
