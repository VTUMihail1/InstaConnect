namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Builders;

public class VerifyEmailConfirmationTokenApiRequestBuilder
{
    private string _id;
    private string _value;

    public VerifyEmailConfirmationTokenApiRequestBuilder(EmailConfirmationToken emailConfirmationToken)
    {
        _id = emailConfirmationToken.Id.Id.Id;
        _value = emailConfirmationToken.Id.Value;
    }

    public VerifyEmailConfirmationTokenApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public VerifyEmailConfirmationTokenApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public VerifyEmailConfirmationTokenApiRequestBuilder WithValue(IStringTransformer transformer)
    {
        _value = transformer.Transform(_value);

        return this;
    }

    public VerifyEmailConfirmationTokenApiRequest Build()
    {
        return new(_id, _value);
    }
}
