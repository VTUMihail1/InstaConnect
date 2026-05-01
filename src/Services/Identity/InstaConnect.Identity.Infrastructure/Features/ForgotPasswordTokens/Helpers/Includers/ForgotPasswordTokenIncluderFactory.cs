using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Includers;

internal class ForgotPasswordTokenIncluderFactory : IForgotPasswordTokenIncluderFactory
{
	private readonly IEnumerable<IForgotPasswordTokenIncluder> _includers;

	public ForgotPasswordTokenIncluderFactory(IEnumerable<IForgotPasswordTokenIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IForgotPasswordTokenIncluder> Create(ICollection<IdentityIncludeDescriptor>? descriptors)
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
			throw new ForgotPasswordTokenIncludeDescriptorsNotSupportedException(descriptors);
		}

		return includers;
	}
}
