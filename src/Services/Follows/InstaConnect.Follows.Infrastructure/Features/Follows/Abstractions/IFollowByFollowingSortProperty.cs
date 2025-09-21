using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowByFollowingSortProperty
{
    public FollowByFollowingSortProperty SortProperty { get; }

    public string Property { get; }
}
