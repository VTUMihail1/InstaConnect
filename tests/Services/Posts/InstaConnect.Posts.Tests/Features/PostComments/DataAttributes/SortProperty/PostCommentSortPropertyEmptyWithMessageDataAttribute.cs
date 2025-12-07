namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentSortPropertyEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<PostCommentSortProperty>;
