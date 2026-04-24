namespace InstaConnect.Chats.Application.Tests.Features.Chats.Builders;

public class AddChatCommandRequestBuilder
{
    private string _participantOneId;
    private string _participantTwoId;

    public AddChatCommandRequestBuilder(User participantOne, User participantTwo)
    {
        _participantOneId = participantOne.Id.Id;
        _participantTwoId = participantTwo.Id.Id;
    }

    public AddChatCommandRequestBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
    {
        _participantOneId = transformer.TryTransform(participantOneId.Id);

        return this;
    }

    public AddChatCommandRequestBuilder WithParticipantOneId(IStringTransformer transformer)
    {
        _participantOneId = transformer.Transform(_participantOneId);

        return this;
    }

    public AddChatCommandRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
    {
        _participantTwoId = transformer.TryTransform(participantTwoId.Id);

        return this;
    }

    public AddChatCommandRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
    {
        _participantTwoId = transformer.Transform(_participantTwoId);

        return this;
    }

    public AddChatCommandRequest Build()
    {
        return new(_participantOneId, _participantTwoId);
    }
}
