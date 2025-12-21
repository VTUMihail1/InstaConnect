using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeSortOrderEmptyDataAttribute : EmptyEnumDataAttribute<CommonSortOrder>;
