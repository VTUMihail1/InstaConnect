using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostEquals
{
    public static bool Matches(this GetAllPostsQuery query, GetAllPostsQueryRequest request, CommonIncludeQuery<PostIncludeProperty> include)
    {
        return query.MatchesFilter(request) &&
               query.MatchesSortable<GetAllPostsQuery, GetAllPostsQueryRequest, PostSortProperty>(request) &&
               query.MatchesPaginatable(request) &&
               query.MatchesIncludable(include);
    }

    public static bool Matches(this GetPostByIdQuery query, GetPostByIdQueryRequest request, CommonIncludeQuery<PostIncludeProperty> include)
    {
        return query.Id.Matches(request.Id) &&
               query.MatchesIncludable(include);
    }

    public static bool Matches(this AddPostCommand command, AddPostCommandRequest request)
    {
        return command.UserId.Matches(request.UserId) &&
               command.Title == request.Title &&
               command.Content == request.Content;
    }

    public static bool Matches(this UpdatePostCommand command, UpdatePostCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.UserId.Matches(request.UserId) &&
               command.Title == request.Title &&
               command.Content == request.Content;
    }

    public static bool Matches(this DeletePostCommand command, DeletePostCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.UserId.Matches(request.UserId);
    }

    public static bool Matches(this AddPostCommandResponse response, Post post)
    {
        return response.Response.Matches(post.Id);
    }

    public static bool Matches(this UpdatePostCommandResponse response, Post post)
    {
        return response.Response.Matches(post.Id);
    }

    public static bool Matches(this GetPostByIdQueryResponse response, Post post)
    {
        return response.Response.Matches(post);
    }

    public static bool Matches(
        this GetAllPostsQueryResponse response,
        ICollection<Post> posts,
        GetAllPostsQueryRequest request)
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
        this GetAllPostsQueryResponse response,
        ICollection<Post> posts,
        GetAllPostsQueryRequest request,
        ISortEnumTermTransformer<Post> termTransformer)
    {
        return response.Response.MatchesCollectionResponse(posts.Count, request) &&
               response.Response.Entities.MatchesSortedCollection(posts,
                                                                  (response, post) => response.Matches(post),
                                                                  termTransformer,
                                                                  request,
                                                                  post => post.MatchesFilter(request));
    }

    public static bool Matches(this Post post, AddPostCommandRequest request)
    {
        return post.UserId.Matches(request.UserId) &&
               post.Title == request.Title &&
               post.Content == request.Content;
    }

    public static bool Matches(this Post post, UpdatePostCommandRequest request)
    {
        return post.Id.Matches(request.Id) &&
               post.UserId.Matches(request.UserId) &&
               post.Title == request.Title &&
               post.Content == request.Content;
    }

    public static bool Matches(this PostIdCommandResponse response, PostId id)
    {
        return id.Matches(response.Id);
    }

    public static bool Matches(this PostQueryResponse response, Post post)
    {
        return post.Id.Matches(response.Id) &&
               post.Title == response.Title &&
               post.Content == response.Content &&
               response.User.Matches(post.User!) &&
               post.CreatedAtUtc == response.CreatedAtUtc &&
               post.UpdatedAtUtc == response.UpdatedAtUtc;
    }

    public static bool MatchesFilter(this GetAllPostsQuery query, GetAllPostsQueryRequest request)
    {
        return query.Filter.UserName.Value == request.UserName &&
               query.Filter.Title == request.Title;
    }

    public static bool MatchesFilter(this Post post, GetAllPostsQueryRequest request)
    {
        return post.User!.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName) &&
               post.Title.StartsWithOrdinalIgnoreCase(request.Title);
    }
}
