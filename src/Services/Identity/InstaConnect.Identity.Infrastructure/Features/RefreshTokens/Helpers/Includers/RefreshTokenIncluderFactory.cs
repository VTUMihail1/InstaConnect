using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Includers;

internal class RefreshTokenIncluderFactory : IRefreshTokenIncluderFactory
{
	private readonly IEnumerable<IRefreshTokenIncluder> _includers;

	public RefreshTokenIncluderFactory(IEnumerable<IRefreshTokenIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IRefreshTokenIncluder> Create(ICollection<IdentityIncludeDescriptor>? descriptors)
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
			throw new RefreshTokenIncludeDescriptorsNotSupportedException(descriptors);
		}

		return includers;
	}
}
