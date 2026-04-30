using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

internal interface IPostCommentsForUserSortTermer : ISortTermer<PostCommentsForUserSortTerm, PostCommentResponse>;
