namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

public class UserClaimIncludeBuilderFactory : IUserClaimIncludeBuilderFactory
{
	private readonly IUserClaimIncludeDescriptorFactory _descriptorFactory;

	public UserClaimIncludeBuilderFactory(IUserClaimIncludeDescriptorFactory descriptorFactory)
	{
		_descriptorFactory = descriptorFactory;
	}

	public UserClaimIncludeBuilder Create()
	{
		return new UserClaimIncludeBuilder([], _descriptorFactory);
	}
}
