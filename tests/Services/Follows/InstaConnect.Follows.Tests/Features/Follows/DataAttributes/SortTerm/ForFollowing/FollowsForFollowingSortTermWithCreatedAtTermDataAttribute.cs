namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm.ForFollowing;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsForFollowingSortTermWithCreatedAtTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<FollowsForFollowingSortTerm, Follow, DateTimeOffset>
{
    public FollowsForFollowingSortTermWithCreatedAtTermDataAttribute()
        : base(FollowsForFollowingSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
    {
    }
}
