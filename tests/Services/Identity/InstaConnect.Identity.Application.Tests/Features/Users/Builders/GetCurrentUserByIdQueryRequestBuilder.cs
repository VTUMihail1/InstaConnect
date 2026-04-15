using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetCurrentUserByIdQueryRequestBuilder
{
    private string _currentId;

    public GetCurrentUserByIdQueryRequestBuilder(User user)
    {
        _currentId = user.Id.Id;
    }

    public GetCurrentUserByIdQueryRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
    {
        _currentId = transformer.TryTransform(currentId.Id);

        return this;
    }

    public GetCurrentUserByIdQueryRequestBuilder WithCurrentId(IStringTransformer transformer)
    {
        _currentId = transformer.Transform(_currentId);

        return this;
    }

    public GetCurrentUserByIdQueryRequest Build()
    {
        return new(_currentId);
    }
}
