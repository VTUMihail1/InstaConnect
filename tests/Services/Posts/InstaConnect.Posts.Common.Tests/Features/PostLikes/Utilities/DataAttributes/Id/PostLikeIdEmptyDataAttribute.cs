using InstaConnect.Common.Tests.Utilities.Types.Strings.Empty;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeIdEmptyDataAttribute : EmptyStringDataAttribute
{
}
