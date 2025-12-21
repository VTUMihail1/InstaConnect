using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
    public static bool Matches(
        this GetAllPostCommentLikesQuery query,
        GetAllPostCommentLikesQueryRequest request,
        CommonIncludeQuery<PostCommentLikeIncludeProperty> include)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentLikesQuery, GetAllPostCommentLikesQueryRequest, PostCommentLikeSortProperty>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesIncludable(include);
    }

    public static bool Matches(
        this GetPostCommentLikeByIdQuery query,
        GetPostCommentLikeByIdQueryRequest request,
        CommonIncludeQuery<PostCommentLikeIncludeProperty> include)
    {
        return query.Id.Matches(request.Id, request.CommentId, request.UserId) &&
               query.MatchesIncludable(include);
    }

    public static bool Matches(this AddPostCommentLikeCommand command, AddPostCommentLikeCommandRequest request)
    {
        return command.CommentId.Matches(request.Id, request.CommentId) &&
               command.UserId.Matches(request.UserId);
    }

    public static bool Matches(this DeletePostCommentLikeCommand command, DeletePostCommentLikeCommandRequest request)
    {
        return command.Id.Matches(request.Id, request.CommentId, request.UserId);
    }

    public static bool Matches(this AddPostCommentLikeCommandResponse response, PostCommentLike postCommentLike)
    {
        return response.Response.Matches(postCommentLike.Id);
    }

    public static bool Matches(this GetPostCommentLikeByIdQueryResponse response, PostCommentLike postCommentLike)
    {
        return response.Response.Matches(postCommentLike);
    }

    public static bool Matches(
        this GetAllPostCommentLikesQueryResponse response,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesQueryRequest request)
    {
        return response.Response.MatchesCollectionResponse(postCommentLikes.Count, request) &&
               response.Response.Entities.MatchesCollection(postCommentLikes,
                                                            response => response.User.Id,
                                                            postCommentLike => postCommentLike.Id.UserId.Id,
                                                            (response, postCommentLike) => response.Matches(postCommentLike),
                                                            request,
                                                            postCommentLike => postCommentLike.MatchesFilter(request));
    }

    public static bool Matches(
        this GetAllPostCommentLikesQueryResponse response,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesQueryRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        return response.Response.MatchesCollectionResponse(postCommentLikes.Count, request) &&
               response.Response.Entities.MatchesSortedCollection(postCommentLikes,
                                                                  (response, postCommentLike) => response.Matches(postCommentLike),
                                                                  termTransformer,
                                                                  request,
                                                                  postCommentLike => postCommentLike.MatchesFilter(request));
    }

    public static bool Matches(this PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest request)
    {
        return postCommentLike.Id.Matches(request.Id, request.CommentId, request.UserId);
    }

    public static bool Matches(this PostCommentLikeIdCommandResponse response, PostCommentLikeId id)
    {
        return id.Matches(response.Id, response.CommentId, response.UserId);
    }

    public static bool Matches(this PostCommentLikeQueryResponse response, PostCommentLike postCommentLike)
    {
        return postCommentLike.Id.Matches(response.Id, response.CommentId, response.User.Id) &&
               response.User.Matches(postCommentLike.User!) &&
               response.CreatedAtUtc == postCommentLike.CreatedAtUtc;
    }

    public static bool MatchesFilter(this GetAllPostCommentLikesQueryRequest query, GetAllPostCommentLikesApiRequest request)
    {
        return query.Id == request.Id &&
               query.UserName == request.UserName;
    }

    public static bool MatchesFilter(this PostCommentLike postCommentLike, GetAllPostCommentLikesApiRequest request)
    {
        return postCommentLike.Id.CommentId.Id.Id == request.Id &&
               postCommentLike.Id.CommentId.CommentId == request.CommentId &&
               postCommentLike.User!.Name.Value == request.UserName;
    }

    public static bool MatchesFilter(this GetAllPostCommentLikesQuery query, GetAllPostCommentLikesQueryRequest request)
    {
        return query.Filter.CommentId.Id.Id == request.Id &&
               query.Filter.CommentId.CommentId == request.CommentId &&
               query.Filter.UserName.Value == request.UserName;
    }

    public static bool MatchesFilter(this PostCommentLike postCommentLike, GetAllPostCommentLikesQueryRequest request)
    {
        return postCommentLike.Id.CommentId.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postCommentLike.Id.CommentId.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
               postCommentLike.User!.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }
}
