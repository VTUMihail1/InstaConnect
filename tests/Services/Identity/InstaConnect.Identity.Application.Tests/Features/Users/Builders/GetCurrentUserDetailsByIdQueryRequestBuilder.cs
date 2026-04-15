using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetCurrentUserDetailsByIdQueryRequestBuilder
{
    private string _currentId;

    public GetCurrentUserDetailsByIdQueryRequestBuilder(User user)
    {
        _currentId = user.Id.Id;
    }

    public GetCurrentUserDetailsByIdQueryRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
    {
        _currentId = transformer.TryTransform(currentId.Id);

        return this;
    }

    public GetCurrentUserDetailsByIdQueryRequestBuilder WithCurrentId(IStringTransformer transformer)
    {
        _currentId = transformer.Transform(_currentId);

        return this;
    }

    public GetCurrentUserDetailsByIdQueryRequest Build()
    {
        return new(_currentId);
    }
}
