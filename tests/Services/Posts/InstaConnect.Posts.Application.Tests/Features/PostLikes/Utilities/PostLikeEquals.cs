using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
    extension(GetAllPostLikesQuery query)
    {
        public bool Matches(GetAllPostLikesQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostLikesQuery, PostLikesSortTerm, PostLikesSortingQuery, GetAllPostLikesQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllPostLikesQuery, PostLikesPaginationQuery, GetAllPostLikesQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostLikesQueryRequest request)
        {
            return query.Filter.Id.Matches(request.Id) &&
                   query.Filter.UserName.Matches(request.UserName);
        }
    }

    extension(GetAllPostLikesForUserQuery query)
    {
        public bool Matches(GetAllPostLikesForUserQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostLikesForUserQuery, PostLikesForUserSortTerm, PostLikesForUserSortingQuery, GetAllPostLikesForUserQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllPostLikesForUserQuery, PostLikesPaginationQuery, GetAllPostLikesForUserQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostLikesForUserQueryRequest request)
        {
            return query.Filter.UserId.Matches(request.UserId);
        }
    }

    extension(GetPostLikeByIdQuery query)
    {
        public bool Matches(GetPostLikeByIdQueryRequest request)
        {
            return query.Id.Matches(request.Id, request.UserId) &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddPostLikeCommand command)
    {
        public bool Matches(AddPostLikeCommandRequest request)
        {
            return command.Id.Matches(request.Id) &&
                   command.UserId.Matches(request.UserId);
        }
    }

    extension(DeletePostLikeCommand command)
    {
        public bool Matches(DeletePostLikeCommandRequest request)
        {
            return command.Id.Matches(request.Id, request.UserId);
        }
    }

    extension(AddPostLikeCommandResponse response)
    {
        public bool Matches(
        PostLike postLike,
        AddPostLikeCommandRequest request)
        {
            return response.Id.Matches(postLike.Id);
        }
    }

    extension(GetPostLikeByIdQueryResponse response)
    {
        public bool Matches(PostLike postLike, GetPostLikeByIdQueryRequest request)
        {
            return response.PostLike.MatchesFull(postLike, request);
        }
    }

    extension(GetAllPostLikesQueryResponse response)
    {
        public bool Matches(
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request)
        {
            return response.PostLikeCollection.MatchesWithoutUser(
                       (response, postLike) => response.MatchesWithoutPost(postLike, request),
                       postLike => postLike.MatchesFilter(request),
                       post,
                       postLikes,
                       request);
        }

        public bool Matches(
            Post post,
            ICollection<PostLike> postLikes,
            GetAllPostLikesQueryRequest request,
            ISortEnumTermTransformer<PostLike> termTransformer)
        {
            return response.PostLikeCollection.MatchesWithoutUser(
                       (response, postLike) => response.MatchesWithoutPost(postLike, request),
                       postLike => postLike.MatchesFilter(request),
                       post,
                       postLikes,
                       request,
                       termTransformer);
        }
    }

    extension(GetAllPostLikesForUserQueryResponse response)
    {
        public bool Matches(
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserQueryRequest request)
        {
            return response.PostLikeCollection.MatchesWithoutPost(
                       (response, postLike) => response.MatchesWithoutUser(postLike, request),
                       postLike => postLike.MatchesFilter(request),
                       user,
                       postLikes,
                       request);
        }

        public bool Matches(
            User user,
            ICollection<PostLike> postLikes,
            GetAllPostLikesForUserQueryRequest request,
            ISortEnumTermTransformer<PostLike> termTransformer)
        {
            return response.PostLikeCollection.MatchesWithoutPost(
                       (response, postLike) => response.MatchesWithoutUser(postLike, request),
                       postLike => postLike.MatchesFilter(request),
                       user,
                       postLikes,
                       request,
                       termTransformer);
        }
    }

    extension(PostLike postLike)
    {
        public bool Matches(AddPostLikeCommandRequest request)
        {
            return postLike.Id.Matches(request.Id, request.UserId);
        }

        public bool MatchesFilter(GetAllPostLikesQueryRequest request)
        {
            return postLike.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
                   postLike.User != null &&
                   postLike.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
        }

        public bool MatchesFilter(GetAllPostLikesForUserQueryRequest request)
        {
            return postLike.Id.UserId.Id.StartsWithOrdinalIgnoreCase(request.UserId);
        }
    }

    extension(PostLikeIdCommandResponse response)
    {
        public bool Matches(PostLikeId id)
        {
            return id.Matches(response.Id, response.UserId);
        }
    }

    extension(PostLikeQueryResponse? response)
    {
        public bool MatchesFull<TRequest>(PostLike? postLike, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   postLike != null &&
                   postLike.Id.Matches(response.Id, response.UserId) &&
                   postLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User.MatchesFull(postLike.User) &&
                   response.Post.MatchesFull(postLike.Post, request);
        }

        public bool MatchesWithoutUser<TRequest>(PostLike? postLike, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   postLike != null &&
                   postLike.Id.Matches(response.Id, response.UserId) &&
                   postLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User == null &&
                   response.Post.MatchesFull(postLike.Post, request);
        }

        public bool MatchesWithoutPost<TRequest>(PostLike? postLike, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   postLike != null &&
                   postLike.Id.Matches(response.Id, response.UserId) &&
                   postLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User.MatchesFull(postLike.User) &&
                   response.Post == null;
        }
    }

    extension(PostLikeCollectionQueryResponse response)
    {
        public bool MatchesWithoutUser<TRequest>(
        Func<PostLikeQueryResponse, PostLike, bool> matches,
        Func<PostLike, bool> matchesFilter,
        Post post,
        ICollection<PostLike> postLikes,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request) &&
                   response.User == null &&
                   response.Post.MatchesFull(post, request) &&
                   response.PostLikes.MatchesCollection(postLikes,
                                                        response => new(new(response.Id), new(response.UserId)),
                                                        postLike => postLike.Id,
                                                        matches,
                                                        request,
                                                        matchesFilter);
        }

        public bool MatchesWithoutUser<TRequest>(
            Func<PostLikeQueryResponse, PostLike, bool> matches,
            Func<PostLike, bool> matchesFilter,
            Post post,
            ICollection<PostLike> postLikes,
            TRequest request,
            ISortEnumTermTransformer<PostLike> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request) &&
                   response.User == null &&
                   response.Post.MatchesFull(post, request) &&
                   response.PostLikes.MatchesSortedCollection(postLikes,
                                                              matches,
                                                              termTransformer,
                                                              request,
                                                              matchesFilter);
        }

        public bool MatchesWithoutPost<TRequest>(
            Func<PostLikeQueryResponse, PostLike, bool> matches,
            Func<PostLike, bool> matchesFilter,
            User user,
            ICollection<PostLike> postLikes,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request) &&
                   response.User.MatchesFull(user) &&
                   response.Post == null &&
                   response.PostLikes.MatchesCollection(postLikes,
                                                        response => new(new(response.Id), new(response.UserId)),
                                                        postLike => postLike.Id,
                                                        matches,
                                                        request,
                                                        matchesFilter);
        }

        public bool MatchesWithoutPost<TRequest>(
            Func<PostLikeQueryResponse, PostLike, bool> matches,
            Func<PostLike, bool> matchesFilter,
            User user,
            ICollection<PostLike> postLikes,
            TRequest request,
            ISortEnumTermTransformer<PostLike> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postLikes.Count(matchesFilter), request) &&
                   response.User.MatchesFull(user) &&
                   response.Post == null &&
                   response.PostLikes.MatchesSortedCollection(postLikes,
                                                              matches,
                                                              termTransformer,
                                                              request,
                                                              matchesFilter);
        }
    }
}
