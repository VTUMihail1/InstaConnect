namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.SortProperties;
internal class ChatByParticipantSortPropertyFactory : IChatByParticipantSortPropertyFactory
{
    private readonly IEnumerable<IChatByParticipantSortProperty> _chatByParticipantSortProperties;

    public ChatByParticipantSortPropertyFactory(IEnumerable<IChatByParticipantSortProperty> chatByParticipantSortProperties)
    {
        _chatByParticipantSortProperties = chatByParticipantSortProperties;
    }

    public IChatByParticipantSortProperty Create(ChatByParticipantSortProperty sortProperty)
    {
        var property = _chatByParticipantSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new ChatByParticipantSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
