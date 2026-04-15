namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class ParticipantTwoIncludeBuilderFactory : IParticipantTwoIncludeBuilderFactory
{
    private readonly IParticipantTwoIncludeDescriptorFactory _descriptorFactory;

    public ParticipantTwoIncludeBuilderFactory(IParticipantTwoIncludeDescriptorFactory descriptorFactory)
    {
        _descriptorFactory = descriptorFactory;
    }

    public ParticipantTwoIncludeBuilder Create()
    {
        return new ParticipantTwoIncludeBuilder([], _descriptorFactory);
    }
}
