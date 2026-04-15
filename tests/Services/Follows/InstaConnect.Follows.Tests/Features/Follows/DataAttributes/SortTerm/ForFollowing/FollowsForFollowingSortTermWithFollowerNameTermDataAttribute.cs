namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm.ForFollowing;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsForFollowingSortTermWithFollowerNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<FollowsForFollowingSortTerm, Follow, string>
{
    public FollowsForFollowingSortTermWithFollowerNameTermDataAttribute()
        : base(FollowsForFollowingSortTerm.ByFollowerName, p => p.Follower!.Name.Value)
    {
    }
}
