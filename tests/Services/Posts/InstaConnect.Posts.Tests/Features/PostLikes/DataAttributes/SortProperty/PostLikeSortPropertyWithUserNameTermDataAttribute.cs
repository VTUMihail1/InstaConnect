namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeSortPropertyWithUserNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostLikeSortProperty, PostLike, string>
{
    public PostLikeSortPropertyWithUserNameTermDataAttribute()
        : base(PostLikeSortProperty.ByUserName, p => p.User!.Name.Value)
    {
    }
}
