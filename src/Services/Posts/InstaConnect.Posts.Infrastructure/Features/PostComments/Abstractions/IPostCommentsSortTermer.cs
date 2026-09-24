using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

internal interface IPostCommentsSortTermer : ISortTermer<PostCommentsSortTerm, PostCommentResponse>;
