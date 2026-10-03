using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentsSortTermer : ISortTermer<PostCommentsSortTerm, PostCommentResponse>;
