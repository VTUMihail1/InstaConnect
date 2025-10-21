using InstaConnect.PostComments.Domain.Features.PostComments.Helpers;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;

public interface IPostCommentIncludeQueryBuilderFactory
{
    PostCommentIncludeQueryBuilder Create();
}