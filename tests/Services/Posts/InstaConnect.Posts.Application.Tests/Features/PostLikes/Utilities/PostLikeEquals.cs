using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
    public static bool Matches(this GetAllPostLikesQuery query, GetAllPostLikesQueryRequest request, CommonIncludeQuery<PostLikeIncludeProperty> include)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostLikesQuery, GetAllPostLikesQueryRequest, PostLikeSortProperty>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesIncludable(include);
    }

    public static bool Matches(this GetPostLikeByIdQuery query, GetPostLikeByIdQueryRequest request, CommonIncludeQuery<PostLikeIncludeProperty> include)
    {
        return query.Id.Matches(request.Id, request.UserId) &&
               query.MatchesIncludable(include);
    }

    public static bool Matches(this AddPostLikeCommand command, AddPostLikeCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.UserId.Matches(request.UserId);
    }

    public static bool Matches(this DeletePostLikeCommand command, DeletePostLikeCommandRequest request)
    {
        return command.Id.Matches(request.Id, request.UserId);
    }

    public static bool Matches(this AddPostLikeCommandResponse response, PostLike postLike)
    {
        return response.Response.Matches(postLike.Id);
    }

    public static bool Matches(this GetPostLikeByIdQueryResponse response, PostLike postLike)
    {
        return response.Response.Matches(postLike);
    }

    public static bool Matches(
        this GetAllPostLikesQueryResponse response,
        ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request)
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
        this GetAllPostLikesQueryResponse response,
        ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request,
        ISortEnumTermTransformer<PostLike> termTransformer)
    {
        return response.Response.MatchesCollectionResponse(postLikes.Count, request) &&
               response.Response.Entities.MatchesSortedCollection(postLikes,
                                                                  (response, postLike) => response.Matches(postLike),
                                                                  termTransformer,
                                                                  request,
                                                                  postLike => postLike.MatchesFilter(request));
    }

    public static bool Matches(this PostLike postLike, AddPostLikeCommandRequest request)
    {
        return postLike.Id.Matches(request.Id, request.UserId);
    }

    public static bool Matches(this PostLikeIdCommandResponse response, PostLikeId id)
    {
        return id.Matches(response.Id, response.UserId);
    }

    public static bool Matches(this PostLikeQueryResponse response, PostLike postLike)
    {
        return postLike.Id.Matches(response.Id, response.User.Id) &&
               response.User.Matches(postLike.User!) &&
               response.CreatedAtUtc == postLike.CreatedAtUtc;
    }

    public static bool MatchesFilter(this GetAllPostLikesQuery query, GetAllPostLikesQueryRequest request)
    {
        return query.Filter.Id.Id == request.Id &&
               query.Filter.UserName.Value == request.UserName;
    }

    public static bool MatchesFilter(this PostLike postLike, GetAllPostLikesQueryRequest request)
    {
        return postLike.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
               postLike.User!.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
    }
}
