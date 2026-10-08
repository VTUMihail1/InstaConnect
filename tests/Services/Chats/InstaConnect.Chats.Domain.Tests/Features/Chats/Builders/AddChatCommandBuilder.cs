namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;

public class AddChatCommandBuilder
{
	private string _participantOneId;
	private string _participantTwoId;

	public AddChatCommandBuilder(User participantOne, User participantTwo)
	{
		_participantOneId = participantOne.Id.Id;
		_participantTwoId = participantTwo.Id.Id;
	}

	public AddChatCommandBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public AddChatCommandBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public AddChatCommandBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public AddChatCommandBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public AddChatCommand Build()
	{
		return new(
			new(_participantOneId),
			new(_participantTwoId));
	}
}
