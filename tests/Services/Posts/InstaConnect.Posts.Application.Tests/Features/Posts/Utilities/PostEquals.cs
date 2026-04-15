using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostEquals
{
    extension(GetAllPostsQuery query)
    {
        public bool Matches(GetAllPostsQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostsQuery, PostsSortTerm, PostsSortingQuery, GetAllPostsQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllPostsQuery, PostsPaginationQuery, GetAllPostsQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostsQueryRequest request)
        {
            return query.Filter.UserName.Matches(request.UserName) &&
                   query.Filter.Title == request.Title;
        }
    }

    extension(GetAllPostsForUserQuery query)
    {
        public bool Matches(GetAllPostsForUserQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostsForUserQuery, PostsForUserSortTerm, PostsForUserSortingQuery, GetAllPostsForUserQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllPostsForUserQuery, PostsPaginationQuery, GetAllPostsForUserQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostsForUserQueryRequest request)
        {
            return query.Filter.UserId.Matches(request.UserId) &&
                   query.Filter.Title == request.Title;
        }
    }

    extension(GetPostByIdQuery query)
    {
        public bool Matches(GetPostByIdQueryRequest request)
        {
            return query.Id.Matches(request.Id) &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddPostCommand command)
    {
        public bool Matches(AddPostCommandRequest request)
        {
            return command.UserId.Matches(request.UserId) &&
                   command.Title == request.Title &&
                   command.Content == request.Content;
        }
    }

    extension(UpdatePostCommand command)
    {
        public bool Matches(UpdatePostCommandRequest request)
        {
            return command.Id.Matches(request.Id) &&
                   command.UserId.Matches(request.UserId) &&
                   command.Title == request.Title &&
                   command.Content == request.Content;
        }
    }

    extension(DeletePostCommand command)
    {
        public bool Matches(DeletePostCommandRequest request)
        {
            return command.Id.Matches(request.Id) &&
                   command.UserId.Matches(request.UserId);
        }
    }

    extension(AddPostCommandResponse response)
    {
        public bool Matches(Post post, AddPostCommandRequest request)
        {
            return response.Id.Matches(post.Id);
        }
    }

    extension(UpdatePostCommandResponse response)
    {
        public bool Matches(Post post, UpdatePostCommandRequest request)
        {
            return response.Id.Matches(post.Id);
        }
    }

    extension(GetPostByIdQueryResponse response)
    {
        public bool Matches(Post post, GetPostByIdQueryRequest request)
        {
            return response.Post.MatchesFull(post, request);
        }
    }

    extension(GetAllPostsQueryResponse response)
    {
        public bool Matches(
        ICollection<Post> posts,
        GetAllPostsQueryRequest request)
        {
            return response.PostCollection.MatchesWithoutUser(
                       (response, post) => response.MatchesFull(post, request),
                       post => post.MatchesFilter(request),
                       posts,
                       request);
        }

        public bool Matches(
            ICollection<Post> posts,
            GetAllPostsQueryRequest request,
            ISortEnumTermTransformer<Post> termTransformer)
        {
            return response.PostCollection.MatchesWithoutUser(
                       (response, post) => response.MatchesFull(post, request),
                       post => post.MatchesFilter(request),
                       posts,
                       request,
                       termTransformer);
        }
    }

    extension(GetAllPostsForUserQueryResponse response)
    {
        public bool Matches(
        User user,
        ICollection<Post> posts,
        GetAllPostsForUserQueryRequest request)
        {
            return response.PostCollection.MatchesFull(
                       (response, post) => response.MatchesWithoutUser(post, request),
                       post => post.MatchesFilter(request),
                       user,
                       posts,
                       request);
        }

        public bool Matches(
            User user,
            ICollection<Post> posts,
            GetAllPostsForUserQueryRequest request,
            ISortEnumTermTransformer<Post> termTransformer)
        {
            return response.PostCollection.MatchesFull(
                       (response, post) => response.MatchesWithoutUser(post, request),
                       post => post.MatchesFilter(request),
                       user,
                       posts,
                       request,
                       termTransformer);
        }
    }

    extension(Post post)
    {
        public bool Matches(AddPostCommandRequest request)
        {
            return post.UserId.Matches(request.UserId) &&
                   post.Title == request.Title &&
                   post.Content == request.Content;
        }

        public bool Matches(UpdatePostCommandRequest request)
        {
            return post.Id.Matches(request.Id) &&
                   post.UserId.Matches(request.UserId) &&
                   post.Title == request.Title &&
                   post.Content == request.Content;
        }

        public bool MatchesFilter(GetAllPostsQueryRequest request)
        {
            return post.User != null &&
                   post.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName) &&
                   post.Title.StartsWithOrdinalIgnoreCase(request.Title);
        }

        public bool MatchesFilter(GetAllPostsForUserQueryRequest request)
        {
            return post.UserId.Id.StartsWithOrdinalIgnoreCase(request.UserId) &&
                   post.Title.StartsWithOrdinalIgnoreCase(request.Title);
        }
    }

    extension(PostIdCommandResponse response)
    {
        public bool Matches(PostId id)
        {
            return id.Matches(response.Id);
        }
    }

    extension(PostQueryResponse? response)
    {
        public bool MatchesFull<TRequest>(Post? post, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   post != null &&
                   post.Id.Matches(response.Id) &&
                   post.UserId.Matches(response.UserId) &&
                   post.Title == response.Title &&
                   post.Content == response.Content &&
                   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
                   post.CreatedAtUtc == response.CreatedAtUtc &&
                   post.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.User.MatchesFull(post.User);
        }

        public bool MatchesWithoutUser<TRequest>(Post? post, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   post != null &&
                   post.Id.Matches(response.Id) &&
                   post.UserId.Matches(response.UserId) &&
                   post.Title == response.Title &&
                   post.Content == response.Content &&
                   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
                   post.CreatedAtUtc == response.CreatedAtUtc &&
                   post.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.User == null;
        }
    }

    extension(PostCollectionQueryResponse response)
    {
        public bool MatchesFull<TRequest>(
        Func<PostQueryResponse, Post, bool> matches,
        Func<Post, bool> matchesFilter,
        User user,
        ICollection<Post> posts,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(posts.Count(matchesFilter), request) &&
                   response.User.MatchesFull(user) &&
                   response.Posts.MatchesCollection(posts,
                                                    response => new(response.Id),
                                                    post => post.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
        }

        public bool MatchesFull<TRequest>(
            Func<PostQueryResponse, Post, bool> matches,
            Func<Post, bool> matchesFilter,
            User user,
            ICollection<Post> posts,
            TRequest request,
            ISortEnumTermTransformer<Post> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(posts.Count(matchesFilter), request) &&
                   response.User.MatchesFull(user) &&
                   response.Posts.MatchesSortedCollection(posts,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
        }

        public bool MatchesWithoutUser<TRequest>(
            Func<PostQueryResponse, Post, bool> matches,
            Func<Post, bool> matchesFilter,
            ICollection<Post> posts,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(posts.Count(matchesFilter), request) &&
                   response.User == null &&
                   response.Posts.MatchesCollection(posts,
                                                    response => new(response.Id),
                                                    post => post.Id,
                                                    matches,
                                                    request,
                                                    matchesFilter);
        }

        public bool MatchesWithoutUser<TRequest>(
            Func<PostQueryResponse, Post, bool> matches,
            Func<Post, bool> matchesFilter,
            ICollection<Post> posts,
            TRequest request,
            ISortEnumTermTransformer<Post> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(posts.Count(matchesFilter), request) &&
                   response.User == null &&
                   response.Posts.MatchesSortedCollection(posts,
                                                          matches,
                                                          termTransformer,
                                                          request,
                                                          matchesFilter);
        }
    }
}
