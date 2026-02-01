namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowIncludeProperty : IIncluder<Follow>
{
    public FollowIncludeProperty IncludeProperty { get; }
}
