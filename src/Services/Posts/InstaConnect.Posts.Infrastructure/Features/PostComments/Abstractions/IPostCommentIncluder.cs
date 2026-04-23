using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

internal interface IPostCommentIncluder : IIncluder<PostComment, PostsIncludeType, PostsDestinationType>;
