namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostLikePageEmptyWithMessageDataAttribute()
        : base(PostLikeErrorMessages.GetPageEmpty())
    {
    }
}
