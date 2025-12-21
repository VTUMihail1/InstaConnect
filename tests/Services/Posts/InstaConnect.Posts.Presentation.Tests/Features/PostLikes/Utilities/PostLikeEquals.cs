using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
    public static bool Matches(this GetAllPostLikesQueryRequest query, GetAllPostLikesApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostLikesQueryRequest, GetAllPostLikesApiRequest, PostLikeSortProperty>(request) &&
               query.MatchesPaginatable(request);
    }

    public static bool Matches(this GetPostLikeByIdQueryRequest query, GetPostLikeByIdApiRequest request)
    {
        return query.Id == request.Id &&
               query.UserId == request.UserId;
    }

    public static bool Matches(this AddPostLikeCommandRequest command, AddPostLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this DeletePostLikeCommandRequest command, DeletePostLikeApiRequest request)
    {
        return command.Id == request.Id &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this AddPostLikeApiResponse response, PostLike postLike)
    {
        return response.Response.Matches(postLike.Id);
    }

    public static bool Matches(this GetPostLikeByIdApiResponse response, PostLike postLike)
    {
        return response.Response.Matches(postLike);
    }

    public static bool Matches(
        this GetAllPostLikesApiResponse response,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request)
    {
        return response.Response.MatchesCollectionResponse(postLikes.Count, request) &&
               response.Response.Entities.MatchesCollection(postLikes,
                                                            response => response.User.Id,
                                                            postLike => postLike.Id.UserId.Id,
                                                            (response, postLike) => response.Matches(postLike),
                                                            request,
                                                            postLike => postLike.MatchesFilter(request));
    }

    public static bool Matches(
        this GetAllPostLikesApiResponse response,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
    {
        return response.Response.MatchesCollectionResponse(postLikes.Count, request) &&
               response.Response.Entities.MatchesSortedCollection(postLikes,
                                                                  (response, postLike) => response.Matches(postLike),
                                                                  termTransformer,
                                                                  request,
                                                                  postLike => postLike.MatchesFilter(request));
    }

    public static bool Matches(this PostLike postLike, AddPostLikeApiRequest request)
    {
        return postLike.Id.Matches(request.Id, request.UserId);
    }

    public static bool Matches(this PostLikeIdApiResponse response, PostLikeId id)
    {
        return id.Matches(response.Id, response.UserId);
    }

    public static bool Matches(this PostLikeApiResponse response, PostLike postLike)
    {
        return postLike.Id.Matches(response.Id, response.User.Id) &&
               response.User.Matches(postLike.User!) &&
               response.CreatedAtUtc == postLike.CreatedAtUtc;
    }

    public static bool MatchesFilter(this GetAllPostLikesQueryRequest query, GetAllPostLikesApiRequest request)
    {
        return query.Id == request.Id &&
               query.UserName == request.UserName;
    }

    public static bool MatchesFilter(this PostLike postLike, GetAllPostLikesApiRequest request)
    {
        return postLike.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postLike.User!.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }
}
