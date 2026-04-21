using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostEquals
{
    extension(GetAllPostsQueryRequest query)
    {
        public bool Matches(GetAllPostsApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostsQueryRequest, PostsSortTerm, GetAllPostsApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostsApiRequest request)
        {
            return query.UserName == request.UserName &&
                   query.Title == request.Title;
        }
    }

    extension(GetAllPostsForUserQueryRequest query)
    {
        public bool Matches(GetAllPostsForUserApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostsForUserQueryRequest, PostsForUserSortTerm, GetAllPostsForUserApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostsForUserApiRequest request)
        {
            return query.UserId == request.UserId &&
                   query.Title == request.Title;
        }
    }

    extension(GetPostByIdQueryRequest query)
    {
        public bool Matches(GetPostByIdApiRequest request)
        {
            return query.Id == request.Id &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddPostCommandRequest command)
    {
        public bool Matches(AddPostApiRequest request)
        {
            return command.Title == request.Body.Title &&
                   command.Content == request.Body.Content &&
                   command.UserId == request.UserId;
        }
    }

    extension(UpdatePostCommandRequest command)
    {
        public bool Matches(UpdatePostApiRequest request)
        {
            return command.Id == request.Id &&
                   command.Title == request.Body.Title &&
                   command.Content == request.Body.Content &&
                   command.UserId == request.UserId;
        }
    }

    extension(DeletePostCommandRequest command)
    {
        public bool Matches(DeletePostApiRequest request)
        {
            return command.Id == request.Id &&
                   command.UserId == request.UserId;
        }
    }

    extension(AddPostApiResponse response)
    {
        public bool Matches(
        Post post,
        AddPostApiRequest request)
        {
            return response.Id.Matches(post.Id);
        }
    }

    extension(UpdatePostApiResponse response)
    {
        public bool Matches(
        Post post,
        UpdatePostApiRequest request)
        {
            return response.Id.Matches(post.Id);
        }
    }

    extension(GetPostByIdApiResponse response)
    {
        public bool Matches(Post post, GetPostByIdApiRequest request)
        {
            return response.Post.MatchesFull(post, request);
        }
    }

    extension(GetAllPostsApiResponse response)
    {
        public bool Matches(
        ICollection<Post> posts,
        GetAllPostsApiRequest request)
        {
            return response.PostCollection.MatchesWithoutUser(
                       (response, post) => response.MatchesFull(post, request),
                       post => post.MatchesFilter(request),
                       posts,
                       request);
        }

        public bool Matches(
            ICollection<Post> posts,
            GetAllPostsApiRequest request,
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

    extension(GetAllPostsForUserApiResponse response)
    {
        public bool Matches(
        User user,
        ICollection<Post> posts,
        GetAllPostsForUserApiRequest request)
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
            GetAllPostsForUserApiRequest request,
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
        public bool Matches(AddPostApiRequest request)
        {
            return post.UserId.Matches(request.UserId) &&
                   post.Title == request.Body.Title &&
                   post.Content == request.Body.Content;
        }

        public bool Matches(UpdatePostApiRequest request)
        {
            return post.Id.Matches(request.Id) &&
                   post.UserId.Matches(request.UserId) &&
                   post.Title == request.Body.Title &&
                   post.Content == request.Body.Content;
        }

        public bool MatchesFilter(GetAllPostsApiRequest request)
        {
            return post.User != null &&
                   post.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName) &&
                   post.Title.StartsWithOrdinalIgnoreCase(request.Title);
        }

        public bool MatchesFilter(GetAllPostsForUserApiRequest request)
        {
            return post.UserId.Id.StartsWithOrdinalIgnoreCase(request.UserId) &&
                   post.Title.StartsWithOrdinalIgnoreCase(request.Title);
        }
    }

    extension(PostIdApiResponse response)
    {
        public bool Matches(PostId id)
        {
            return id.Matches(response.Id);
        }
    }

    extension(PostApiResponse? response)
    {
        public bool MatchesFull<TRequest>(Post? post, TRequest request)
        where TRequest : ICurrentUserableApiRequest
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
            where TRequest : ICurrentUserableApiRequest
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

    extension(PostCollectionApiResponse response)
    {
        public bool MatchesFull<TRequest>(
        Func<PostApiResponse, Post, bool> matches,
        Func<Post, bool> matchesFilter,
        User user,
        ICollection<Post> posts,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<PostApiResponse, Post, bool> matches,
            Func<Post, bool> matchesFilter,
            User user,
            ICollection<Post> posts,
            TRequest request,
            ISortEnumTermTransformer<Post> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<PostApiResponse, Post, bool> matches,
            Func<Post, bool> matchesFilter,
            ICollection<Post> posts,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<PostApiResponse, Post, bool> matches,
            Func<Post, bool> matchesFilter,
            ICollection<Post> posts,
            TRequest request,
            ISortEnumTermTransformer<Post> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
