namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

public class UserIncludeBuilderFactory : IUserIncludeBuilderFactory
{
	private readonly IUserIncludeDescriptorFactory _descriptorFactory;

	public UserIncludeBuilderFactory(IUserIncludeDescriptorFactory descriptorFactory)
	{
		_descriptorFactory = descriptorFactory;
	}

	public UserIncludeBuilder Create()
	{
		return new UserIncludeBuilder([], _descriptorFactory);
	}
}
