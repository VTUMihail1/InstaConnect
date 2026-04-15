namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenIncludeBuilderFactory : IForgotPasswordTokenIncludeBuilderFactory
{
    private readonly IForgotPasswordTokenIncludeDescriptorFactory _descriptorFactory;

    public ForgotPasswordTokenIncludeBuilderFactory(IForgotPasswordTokenIncludeDescriptorFactory descriptorFactory)
    {
        _descriptorFactory = descriptorFactory;
    }

    public ForgotPasswordTokenIncludeBuilder Create()
    {
        return new ForgotPasswordTokenIncludeBuilder([], _descriptorFactory);
    }
}
