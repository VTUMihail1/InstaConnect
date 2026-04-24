using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatMessageIncluderFactory : IChatMessageIncluderFactory
{
    private readonly IEnumerable<IChatMessageIncluder> _includers;

    public ChatMessageIncluderFactory(IEnumerable<IChatMessageIncluder> includers)
    {
        _includers = includers;
    }

    public IEnumerable<IChatMessageIncluder> Create(ICollection<ChatsIncludeDescriptor>? descriptors)
    {
        if (descriptors == null)
        {
            return [];
        }

        var includers = _includers.Where(s => descriptors.Any(p =>
                                                        p.IncludeType == s.IncludeType &&
                                                        p.DestinationType == s.DestinationType));

        if (includers.IsEmpty())
        {
            throw new ChatMessageIncludeDescriptorsNotSupportedException(descriptors);
        }

        return includers;
    }
}
