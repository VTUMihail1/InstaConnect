namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Builders;

public class AddChatApiRequestBuilder
{
	private string _participantOneId;
	private string _participantTwoId;

	public AddChatApiRequestBuilder(User participantOne, User participantTwo)
	{
		_participantOneId = participantOne.Id.Id;
		_participantTwoId = participantTwo.Id.Id;
	}

	public AddChatApiRequestBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public AddChatApiRequestBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public AddChatApiRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public AddChatApiRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public AddChatApiRequest Build()
	{
		return new(_participantOneId, new(_participantTwoId));
	}
}
