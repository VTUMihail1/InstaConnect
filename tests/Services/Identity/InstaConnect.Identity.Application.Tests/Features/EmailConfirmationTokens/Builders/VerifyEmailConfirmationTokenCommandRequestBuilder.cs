namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Builders;

public class VerifyEmailConfirmationTokenCommandRequestBuilder
{
    private string _id;
    private string _value;

    public VerifyEmailConfirmationTokenCommandRequestBuilder(EmailConfirmationToken emailConfirmationToken)
    {
        _id = emailConfirmationToken.Id.Id.Id;
        _value = emailConfirmationToken.Id.Value;
    }

    public VerifyEmailConfirmationTokenCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public VerifyEmailConfirmationTokenCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public VerifyEmailConfirmationTokenCommandRequestBuilder WithValue(IStringTransformer transformer)
    {
        _value = transformer.Transform(_value);

        return this;
    }

    public VerifyEmailConfirmationTokenCommandRequest Build()
    {
        return new(_id, _value);
    }
}
