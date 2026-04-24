using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includers;

internal class ChatIncluderFactory : IChatIncluderFactory
{
    private readonly IEnumerable<IChatIncluder> _includers;

    public ChatIncluderFactory(IEnumerable<IChatIncluder> includers)
    {
        _includers = includers;
    }

    public IEnumerable<IChatIncluder> Create(ICollection<ChatsIncludeDescriptor>? descriptors)
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
            throw new ChatIncludeDescriptorsNotSupportedException(descriptors);
        }

        return includers;
    }
}
