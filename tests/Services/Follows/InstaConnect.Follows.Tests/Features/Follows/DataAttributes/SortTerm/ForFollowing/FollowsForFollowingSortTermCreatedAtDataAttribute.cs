namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm.ForFollowing;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsForFollowingSortTermCreatedAtDataAttribute
    : SortEnumDataAttribute<FollowsForFollowingSortTerm>
{
    public FollowsForFollowingSortTermCreatedAtDataAttribute()
        : base(FollowsForFollowingSortTerm.ByCreatedAt)
    {
    }
}
