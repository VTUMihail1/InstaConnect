namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsSortTermEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<PostCommentsSortTerm>;
