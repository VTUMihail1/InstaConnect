using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Empty;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeSortPropertyEmptyDataAttribute : EmptyEnumDataAttribute<PostLikeSortProperty>
{
}
