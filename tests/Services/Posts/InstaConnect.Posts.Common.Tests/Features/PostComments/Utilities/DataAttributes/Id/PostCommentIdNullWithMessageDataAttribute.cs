using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Null;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdNullWithMessageDataAttribute : NullStringWithMessageDataAttribute
{
    public PostCommentIdNullWithMessageDataAttribute()
        : base(PostCommentErrorMessages.GetIdEmpty())
    {
    }
}

