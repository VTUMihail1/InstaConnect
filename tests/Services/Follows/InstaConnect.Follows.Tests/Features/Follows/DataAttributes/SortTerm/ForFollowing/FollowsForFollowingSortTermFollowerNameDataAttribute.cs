namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm.ForFollowing;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsForFollowingSortTermFollowerNameDataAttribute
    : SortEnumDataAttribute<FollowsForFollowingSortTerm>
{
    public FollowsForFollowingSortTermFollowerNameDataAttribute()
        : base(FollowsForFollowingSortTerm.ByFollowerName)
    {
    }
}
