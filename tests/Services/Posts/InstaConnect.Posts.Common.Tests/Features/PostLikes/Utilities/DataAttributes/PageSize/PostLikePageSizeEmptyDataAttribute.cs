using InstaConnect.Common.Tests.Utilities.Types.Ints.Empty;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeEmptyDataAttribute : EmptyIntDataAttribute
{
}
