using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUser();
}
