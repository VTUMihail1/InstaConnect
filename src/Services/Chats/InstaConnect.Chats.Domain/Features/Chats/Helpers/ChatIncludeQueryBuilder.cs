namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;

public class ChatIncludeQueryBuilder
{
    private readonly ICollection<ChatIncludeProperty> _includeProperties;

    internal ChatIncludeQueryBuilder(ICollection<ChatIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public ChatIncludeQueryBuilder WithParticipantOne()
    {
        _includeProperties.Add(ChatIncludeProperty.ParticipantOne);

        return this;
    }

    public ChatIncludeQueryBuilder WithParticipantTwo()
    {
        _includeProperties.Add(ChatIncludeProperty.ParticipantTwo);

        return this;
    }

    public ChatIncludeQueryBuilder WithMessages()
    {
        _includeProperties.Add(ChatIncludeProperty.Messages);

        return this;
    }

    public CommonInclude<ChatIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
