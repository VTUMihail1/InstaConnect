using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostEquals
{
    public static bool Matches(this GetAllPostsQueryRequest query, GetAllPostsApiRequest request)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostsQueryRequest, GetAllPostsApiRequest, PostSortProperty>(request) &&
               query.MatchesPaginatable(request);
    }

    public static bool Matches(this GetPostByIdQueryRequest query, GetPostByIdApiRequest request)
    {
        return query.Id == request.Id;
    }

    public static bool Matches(this AddPostCommandRequest command, AddPostApiRequest request)
    {
        return command.Title == request.Body.Title &&
               command.Content == request.Body.Content &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this UpdatePostCommandRequest command, UpdatePostApiRequest request)
    {
        return command.Id == request.Id &&
               command.Title == request.Body.Title &&
               command.Content == request.Body.Content &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this DeletePostCommandRequest command, DeletePostApiRequest request)
    {
        return command.Id == request.Id &&
               command.UserId == request.UserId;
    }

    public static bool Matches(this AddPostApiResponse response, Post post)
    {
        return response.Response.Matches(post.Id);
    }

    public static bool Matches(this UpdatePostApiResponse response, Post post)
    {
        return response.Response.Matches(post.Id);
    }

    public static bool Matches(this GetPostByIdApiResponse response, Post post)
    {
        return response.Response.Matches(post);
    }

    public static bool Matches(
        this GetAllPostsApiResponse response,
        ICollection<Post> posts,
        GetAllPostsApiRequest request)
    {
        return response.Response.MatchesCollectionResponse(posts.Count, request) &&
               response.Response.Entities.MatchesCollection(posts,
                                                            response => response.Id,
                                                            post => post.Id.Id,
                                                            (response, post) => response.Matches(post),
                                                            request,
                                                            post => post.MatchesFilter(request));
    }

    public static bool Matches(
        this GetAllPostsApiResponse response,
        ICollection<Post> posts,
        GetAllPostsApiRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
    {
        return response.Response.MatchesCollectionResponse(posts.Count, request) &&
               response.Response.Entities.MatchesSortedCollection(posts,
                                                                  (response, post) => response.Matches(post),
                                                                  termTransformer,
                                                                  request,
                                                                  post => post.MatchesFilter(request));
    }

    public static bool Matches(this Post post, AddPostApiRequest request)
    {
        return post.UserId.Matches(request.UserId) &&
               post.Title == request.Body.Title &&
               post.Content == request.Body.Content;
    }

    public static bool Matches(this Post post, UpdatePostApiRequest request)
    {
        return post.Id.Matches(request.Id) &&
               post.UserId.Matches(request.UserId) &&
               post.Title == request.Body.Title &&
               post.Content == request.Body.Content;
    }

    public static bool Matches(this PostIdApiResponse response, PostId id)
    {
        return id.Matches(response.Id);
    }

    public static bool Matches(this PostApiResponse response, Post post)
    {
        return post.Id.Matches(response.Id) &&
               post.Title == response.Title &&
               post.Content == response.Content &&
               response.User.Matches(post.User!) &&
               post.CreatedAtUtc == response.CreatedAtUtc &&
               post.UpdatedAtUtc == response.UpdatedAtUtc;
    }

    public static bool MatchesFilter(this GetAllPostsQueryRequest query, GetAllPostsApiRequest request)
    {
        return query.UserName == request.UserName &&
               query.Title == request.Title;
    }

    public static bool MatchesFilter(this Post post, GetAllPostsApiRequest request)
    {
        return post.User!.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName) &&
               post.Title.StartsWithOrdinalIgnoreCase(request.Title);
    }
}
