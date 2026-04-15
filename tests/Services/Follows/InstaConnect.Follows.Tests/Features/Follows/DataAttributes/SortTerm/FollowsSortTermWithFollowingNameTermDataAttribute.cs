namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsSortTermWithFollowingNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<FollowsSortTerm, Follow, string>
{
    public FollowsSortTermWithFollowingNameTermDataAttribute()
        : base(FollowsSortTerm.ByFollowingName, p => p.Following!.Name.Value)
    {
    }
}
