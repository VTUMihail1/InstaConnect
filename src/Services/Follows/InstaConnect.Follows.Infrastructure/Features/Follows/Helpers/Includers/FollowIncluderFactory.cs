using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includers;

internal class FollowIncluderFactory : IFollowIncluderFactory
{
    private readonly IEnumerable<IFollowIncluder> _includers;

    public FollowIncluderFactory(IEnumerable<IFollowIncluder> includers)
    {
        _includers = includers;
    }

    public IEnumerable<IFollowIncluder> Create(ICollection<FollowsIncludeDescriptor>? descriptors)
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
            throw new FollowIncludeDescriptorsNotSupportedException(descriptors);
        }

        return includers;
    }
}
