namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowIncludeProperty : IIncludeProperty<Follow>
{
    public FollowIncludeProperty IncludeProperty { get; }
}
