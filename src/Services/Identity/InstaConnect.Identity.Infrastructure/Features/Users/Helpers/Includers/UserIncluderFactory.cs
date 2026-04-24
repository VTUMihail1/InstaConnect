using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class UserIncluderFactory : IUserIncluderFactory
{
    private readonly IEnumerable<IUserIncluder> _includers;

    public UserIncluderFactory(IEnumerable<IUserIncluder> includers)
    {
        _includers = includers;
    }

    public IEnumerable<IUserIncluder> Create(ICollection<IdentityIncludeDescriptor>? descriptors)
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
            throw new UserIncludeDescriptorsNotSupportedException(descriptors);
        }

        return includers;
    }
}
