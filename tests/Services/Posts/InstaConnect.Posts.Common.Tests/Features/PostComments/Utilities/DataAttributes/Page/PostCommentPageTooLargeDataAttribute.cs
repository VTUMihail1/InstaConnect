using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostCommentPageTooLargeDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.PageTooLarge)
    {
    }
}

