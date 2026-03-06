using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
    extension(GetAllPostLikesQueryRequest query)
    {
        public bool Matches(GetAllPostLikesApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostLikesQueryRequest, PostLikesSortTerm, GetAllPostLikesApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostLikesApiRequest request)
        {
            return query.Id == request.Id &&
                   query.UserName == request.UserName;
        }
    }

    extension(GetAllPostLikesForUserQueryRequest query)
    {
        public bool Matches(GetAllPostLikesForUserApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostLikesForUserQueryRequest, PostLikesForUserSortTerm, GetAllPostLikesForUserApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostLikesForUserApiRequest request)
        {
            return query.UserId == request.UserId;
        }
    }

    extension(GetPostLikeByIdQueryRequest query)
    {
        public bool Matches(GetPostLikeByIdApiRequest request)
        {
            return query.Id == request.Id &&
                   query.UserId == request.UserId &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddPostLikeCommandRequest command)
    {
        public bool Matches(AddPostLikeApiRequest request)
        {
            return command.Id == request.Id &&
                   command.UserId == request.UserId;
        }
    }

    extension(DeletePostLikeCommandRequest command)
    {
        public bool Matches(DeletePostLikeApiRequest request)
        {
            return command.Id == request.Id &&
                   command.UserId == request.UserId;
        }
    }

    extension(AddPostLikeApiResponse response)
    {
        public bool Matches(
        PostLike postLike,
        AddPostLikeApiRequest request)
        {
            return response.Id.Matches(postLike.Id);
        }
    }

    extension(GetPostLikeByIdApiResponse response)
    {
        public bool Matches(PostLike postLike, GetPostLikeByIdApiRequest request)
        {
            return response.PostLike.MatchesFull(postLike, request);
        }
    }

    extension(GetAllPostLikesApiResponse response)
    {
        public bool Matches(
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request)
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
            GetAllPostLikesApiRequest request,
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

    extension(GetAllPostLikesForUserApiResponse response)
    {
        public bool Matches(
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserApiRequest request)
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
            GetAllPostLikesForUserApiRequest request,
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
        public bool Matches(AddPostLikeApiRequest request)
        {
            return postLike.Id.Matches(request.Id, request.UserId);
        }

        public bool MatchesFilter(GetAllPostLikesApiRequest request)
        {
            return postLike.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
                   postLike.User != null &&
                   postLike.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
        }

        public bool MatchesFilter(GetAllPostLikesForUserApiRequest request)
        {
            return postLike.Id.UserId.Id.StartsWithOrdinalIgnoreCase(request.UserId);
        }
    }

    extension(PostLikeIdApiResponse response)
    {
        public bool Matches(PostLikeId id)
        {
            return id.Matches(response.Id, response.UserId);
        }
    }

    extension(PostLikeApiResponse? response)
    {
        public bool MatchesFull<TRequest>(PostLike? postLike, TRequest request)
        where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   postLike != null &&
                   postLike.Id.Matches(response.Id, response.UserId) &&
                   postLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User.MatchesFull(postLike.User) &&
                   response.Post.MatchesFull(postLike.Post, request);
        }

        public bool MatchesWithoutUser<TRequest>(PostLike? postLike, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   postLike != null &&
                   postLike.Id.Matches(response.Id, response.UserId) &&
                   postLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User == null &&
                   response.Post.MatchesFull(postLike.Post, request);
        }

        public bool MatchesWithoutPost<TRequest>(PostLike? postLike, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   postLike != null &&
                   postLike.Id.Matches(response.Id, response.UserId) &&
                   postLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User.MatchesFull(postLike.User) &&
                   response.Post == null;
        }
    }

    extension(PostLikeCollectionApiResponse response)
    {
        public bool MatchesWithoutUser<TRequest>(
        Func<PostLikeApiResponse, PostLike, bool> matches,
        Func<PostLike, bool> matchesFilter,
        Post post,
        ICollection<PostLike> postLikes,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<PostLikeApiResponse, PostLike, bool> matches,
            Func<PostLike, bool> matchesFilter,
            Post post,
            ICollection<PostLike> postLikes,
            TRequest request,
            ISortEnumTermTransformer<PostLike> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<PostLikeApiResponse, PostLike, bool> matches,
            Func<PostLike, bool> matchesFilter,
            User user,
            ICollection<PostLike> postLikes,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<PostLikeApiResponse, PostLike, bool> matches,
            Func<PostLike, bool> matchesFilter,
            User user,
            ICollection<PostLike> postLikes,
            TRequest request,
            ISortEnumTermTransformer<PostLike> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
