using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
    public static bool Matches(this GetAllPostCommentLikesQueryRequest query, GetAllPostCommentLikesApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesApiRequest, PostCommentLikeSortProperty>(request) &&
               query.MatchesPaginatable(request);
    }

    public static bool Matches(this GetPostCommentLikeByIdQueryRequest query, GetPostCommentLikeByIdApiRequest request)
    {
        return query.Id == request.Id &&
               query.CommentId == request.CommentId &&
               query.UserId == request.UserId;
    }

    public static bool Matches(this AddPostCommentLikeCommandRequest command, AddPostCommentLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.CommentId == request.CommentId &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this DeletePostCommentLikeCommandRequest command, DeletePostCommentLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.CommentId == request.CommentId &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this AddPostCommentLikeApiResponse response, PostCommentLike postCommentLike)
    {
        return response.Response.Matches(postCommentLike.Id);
    }

    public static bool Matches(this GetPostCommentLikeByIdApiResponse response, PostCommentLike postCommentLike)
    {
        return response.Response.Matches(postCommentLike);
    }

    public static bool Matches(
        this GetAllPostCommentLikesApiResponse response,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request)
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
        this GetAllPostCommentLikesApiResponse response,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request,
        ISortEnumTermTransformer<PostCommentLike> termTransformer)
    {
        return response.Response.MatchesCollectionResponse(postCommentLikes.Count, request) &&
               response.Response.Entities.MatchesSortedCollection(postCommentLikes,
                                                                  (response, postCommentLike) => response.Matches(postCommentLike),
                                                                  termTransformer,
                                                                  request,
                                                                  postCommentLike => postCommentLike.MatchesFilter(request));
    }

    public static bool Matches(this PostCommentLike postCommentLike, AddPostCommentLikeApiRequest request)
    {
        return postCommentLike.Id.Matches(request.Id, request.CommentId, request.UserId);
    }

    public static bool Matches(this PostCommentLikeIdApiResponse response, PostCommentLikeId id)
    {
        return id.Matches(response.Id, response.CommentId, response.UserId);
    }

    public static bool Matches(this PostCommentLikeApiResponse response, PostCommentLike postCommentLike)
    {
        return postCommentLike.Id.Matches(response.Id, response.CommentId, response.User.Id) &&
               response.User.Matches(postCommentLike.User!) &&
               response.CreatedAtUtc == postCommentLike.CreatedAtUtc;
    }

    public static bool MatchesFilter(this GetAllPostCommentLikesQueryRequest query, GetAllPostCommentLikesApiRequest request)
    {
        return query.Id == request.Id &&
               query.CommentId == request.CommentId &&
               query.UserName == request.UserName;
    }

    public static bool MatchesFilter(this PostCommentLike postCommentLike, GetAllPostCommentLikesApiRequest request)
    {
        return postCommentLike.Id.CommentId.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postCommentLike.Id.CommentId.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
               postCommentLike.User!.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }
}
