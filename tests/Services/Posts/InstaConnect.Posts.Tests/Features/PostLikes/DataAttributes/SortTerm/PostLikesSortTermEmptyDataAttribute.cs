namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesSortTermEmptyDataAttribute : EmptyEnumDataAttribute<PostLikesSortTerm>
{
}
