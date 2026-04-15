namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class DeleteCurrentUserApiRequestBuilder
{
    private string _id;

    public DeleteCurrentUserApiRequestBuilder(User user)
    {
        _id = user.Id.Id;
    }

    public DeleteCurrentUserApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public DeleteCurrentUserApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeleteCurrentUserApiRequest Build()
    {
        return new(_id);
    }
}
