namespace InstaConnect.Posts.Domain.Features.Users.Helpers;

public class UserIncludeBuilderFactory : IUserIncludeBuilderFactory
{
    private readonly IUserIncludeDescriptorsFactory _descriptorsFactory;

    public UserIncludeBuilderFactory(IUserIncludeDescriptorsFactory propertyEntryFactory)
    {
        _descriptorsFactory = propertyEntryFactory;
    }

    public UserIncludeBuilder Create()
    {
        return new UserIncludeBuilder([], _descriptorsFactory);
    }
}
