namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenIncludeBuilderFactory : IEmailConfirmationTokenIncludeBuilderFactory
{
    private readonly IEmailConfirmationTokenIncludeDescriptorFactory _descriptorFactory;

    public EmailConfirmationTokenIncludeBuilderFactory(IEmailConfirmationTokenIncludeDescriptorFactory descriptorFactory)
    {
        _descriptorFactory = descriptorFactory;
    }

    public EmailConfirmationTokenIncludeBuilder Create()
    {
        return new EmailConfirmationTokenIncludeBuilder([], _descriptorFactory);
    }
}
