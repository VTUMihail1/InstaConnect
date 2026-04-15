namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsSortTermWithCreatedAtTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<FollowsSortTerm, Follow, DateTimeOffset>
{
    public FollowsSortTermWithCreatedAtTermDataAttribute()
        : base(FollowsSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
    {
    }
}
