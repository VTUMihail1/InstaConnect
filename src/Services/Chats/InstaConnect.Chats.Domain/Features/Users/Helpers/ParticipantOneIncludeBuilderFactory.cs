namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class ParticipantOneIncludeBuilderFactory : IParticipantOneIncludeBuilderFactory
{
	private readonly IParticipantOneIncludeDescriptorFactory _descriptorFactory;

	public ParticipantOneIncludeBuilderFactory(IParticipantOneIncludeDescriptorFactory descriptorFactory)
	{
		_descriptorFactory = descriptorFactory;
	}

	public ParticipantOneIncludeBuilder Create()
	{
		return new ParticipantOneIncludeBuilder([], _descriptorFactory);
	}
}
