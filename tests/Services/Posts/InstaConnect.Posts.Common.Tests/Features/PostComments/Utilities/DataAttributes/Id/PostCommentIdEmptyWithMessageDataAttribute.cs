using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Empty;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostCommentIdEmptyWithMessageDataAttribute()
        : base(PostCommentErrorMessages.GetIdEmpty())
    {
    }
}

