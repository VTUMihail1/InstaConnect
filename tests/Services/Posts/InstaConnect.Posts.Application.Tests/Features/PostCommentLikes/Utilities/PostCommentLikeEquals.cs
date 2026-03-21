using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
    extension(GetAllPostCommentLikesQuery query)
    {
        public bool Matches(GetAllPostCommentLikesQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostCommentLikesQuery, PostCommentLikesSortTerm, PostCommentLikesSortingQuery, GetAllPostCommentLikesQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllPostCommentLikesQuery, PostCommentLikesPaginationQuery, GetAllPostCommentLikesQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostCommentLikesQueryRequest request)
        {
            return query.Filter.CommentId.Matches(request.Id, request.CommentId) &&
                   query.Filter.UserName.Matches(request.UserName);
        }
    }

    extension(GetAllPostCommentLikesForUserQuery query)
    {
        public bool Matches(GetAllPostCommentLikesForUserQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostCommentLikesForUserQuery, PostCommentLikesForUserSortTerm, PostCommentLikesForUserSortingQuery, GetAllPostCommentLikesForUserQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllPostCommentLikesForUserQuery, PostCommentLikesPaginationQuery, GetAllPostCommentLikesForUserQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostCommentLikesForUserQueryRequest request)
        {
            return query.Filter.UserId.Matches(request.UserId);
        }
    }

    extension(GetPostCommentLikeByIdQuery query)
    {
        public bool Matches(GetPostCommentLikeByIdQueryRequest request)
        {
            return query.Id.Matches(request.Id, request.CommentId, request.UserId) &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddPostCommentLikeCommand command)
    {
        public bool Matches(AddPostCommentLikeCommandRequest request)
        {
            return command.CommentId.Matches(request.Id, request.CommentId) &&
                   command.UserId.Matches(request.UserId);
        }
    }

    extension(DeletePostCommentLikeCommand command)
    {
        public bool Matches(DeletePostCommentLikeCommandRequest request)
        {
            return command.Id.Matches(request.Id, request.CommentId, request.UserId);
        }
    }

    extension(AddPostCommentLikeCommandResponse response)
    {
        public bool Matches(PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest request)
        {
            return response.Id.Matches(postCommentLike.Id);
        }
    }

    extension(GetPostCommentLikeByIdQueryResponse response)
    {
        public bool Matches(PostCommentLike postCommentLike, GetPostCommentLikeByIdQueryRequest request)
        {
            return response.PostCommentLike.MatchesFull(postCommentLike, request);
        }
    }

    extension(GetAllPostCommentLikesQueryResponse response)
    {
        public bool Matches(PostComment postComment, ICollection<PostCommentLike> postCommentLikes, GetAllPostCommentLikesQueryRequest request)
        {
            return response.PostCommentLikeCollection.MatchesWithoutUser(
                       (response, postCommentLike) => response.MatchesWithoutPostComment(postCommentLike, request),
                       postCommentLike => postCommentLike.MatchesFilter(request),
                       postComment,
                       postCommentLikes,
                       request);
        }

        public bool Matches(PostComment postComment, ICollection<PostCommentLike> postCommentLikes, GetAllPostCommentLikesQueryRequest request, ISortEnumTermTransformer<PostCommentLike> termTransformer)
        {
            return response.PostCommentLikeCollection.MatchesWithoutUser(
                       (response, postCommentLike) => response.MatchesWithoutPostComment(postCommentLike, request),
                       postCommentLike => postCommentLike.MatchesFilter(request),
                       postComment,
                       postCommentLikes,
                       request,
                       termTransformer);
        }
    }

    extension(GetAllPostCommentLikesForUserQueryResponse response)
    {
        public bool Matches(User user, ICollection<PostCommentLike> postCommentLikes, GetAllPostCommentLikesForUserQueryRequest request)
        {
            return response.PostCommentLikeCollection.MatchesWithoutPostComment(
                       (response, postCommentLike) => response.MatchesWithoutUser(postCommentLike, request),
                       postCommentLike => postCommentLike.MatchesFilter(request),
                       user,
                       postCommentLikes,
                       request);
        }

        public bool Matches(User user, ICollection<PostCommentLike> postCommentLikes, GetAllPostCommentLikesForUserQueryRequest request, ISortEnumTermTransformer<PostCommentLike> termTransformer)
        {
            return response.PostCommentLikeCollection.MatchesWithoutPostComment(
                       (response, postCommentLike) => response.MatchesWithoutUser(postCommentLike, request),
                       postCommentLike => postCommentLike.MatchesFilter(request),
                       user,
                       postCommentLikes,
                       request,
                       termTransformer);
        }
    }

    extension(PostCommentLike postCommentLike)
    {
        public bool Matches(AddPostCommentLikeCommandRequest request)
        {
            return postCommentLike.Id.Matches(request.Id, request.CommentId, request.UserId);
        }

        public bool MatchesFilter(GetAllPostCommentLikesQueryRequest request)
        {
            return postCommentLike.Id.CommentId.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
                   postCommentLike.Id.CommentId.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
                   postCommentLike.User != null &&
                   postCommentLike.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
        }

        public bool MatchesFilter(GetAllPostCommentLikesForUserQueryRequest request)
        {
            return postCommentLike.Id.UserId.Id.EqualsOrdinalIgnoreCase(request.UserId);
        }
    }

    extension(PostCommentLikeIdCommandResponse response)
    {
        public bool Matches(PostCommentLikeId id)
        {
            return id.Matches(response.Id, response.CommentId, response.UserId);
        }
    }

    extension(PostCommentLikeQueryResponse? response)
    {
        public bool MatchesFull<TRequest>(PostCommentLike? postCommentLike, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   postCommentLike != null &&
                   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
                   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User.MatchesFull(postCommentLike.User) &&
                   response.PostComment.MatchesFull(postCommentLike.PostComment, request);
        }

        public bool MatchesWithoutPostComment<TRequest>(PostCommentLike? postCommentLike, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   postCommentLike != null &&
                   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
                   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User.MatchesFull(postCommentLike.User) &&
                   response.PostComment == null;
        }

        public bool MatchesWithoutUser<TRequest>(PostCommentLike? postCommentLike, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   postCommentLike != null &&
                   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
                   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User == null &&
                   response.PostComment.MatchesFull(postCommentLike.PostComment, request);
        }
    }

    extension(PostCommentLikeCollectionQueryResponse response)
    {
        public bool MatchesWithoutUser<TRequest>(
            Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
            Func<PostCommentLike, bool> matchesFilter,
            PostComment postComment,
            ICollection<PostCommentLike> postCommentLikes,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request) &&
                   response.User == null &&
                   response.PostComment.MatchesFull(postComment, request) &&
                   response.PostCommentLikes.MatchesCollection(postCommentLikes,
                                                        response => new(new(new(response.Id), response.CommentId), new(response.UserId)),
                                                        postCommentLike => postCommentLike.Id,
                                                        matches,
                                                        request,
                                                        matchesFilter);
        }

        public bool MatchesWithoutUser<TRequest>(
            Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
            Func<PostCommentLike, bool> matchesFilter,
            PostComment postComment,
            ICollection<PostCommentLike> postCommentLikes,
            TRequest request,
            ISortEnumTermTransformer<PostCommentLike> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request) &&
                   response.User == null &&
                   response.PostComment.MatchesFull(postComment, request) &&
                   response.PostCommentLikes.MatchesSortedCollection(postCommentLikes,
                                                              matches,
                                                              termTransformer,
                                                              request,
                                                              matchesFilter);
        }

        public bool MatchesWithoutPostComment<TRequest>(
            Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
            Func<PostCommentLike, bool> matchesFilter,
            User user,
            ICollection<PostCommentLike> postCommentLikes,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request) &&
                   response.User.MatchesFull(user) &&
                   response.PostComment == null &&
                   response.PostCommentLikes.MatchesCollection(postCommentLikes,
                                                        response => new(new(new(response.Id), response.CommentId), new(response.UserId)),
                                                        postCommentLike => postCommentLike.Id,
                                                        matches,
                                                        request,
                                                        matchesFilter);
        }

        public bool MatchesWithoutPostComment<TRequest>(
            Func<PostCommentLikeQueryResponse, PostCommentLike, bool> matches,
            Func<PostCommentLike, bool> matchesFilter,
            User user,
            ICollection<PostCommentLike> postCommentLikes,
            TRequest request,
            ISortEnumTermTransformer<PostCommentLike> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postCommentLikes.Count(matchesFilter), request) &&
                   response.User.MatchesFull(user) &&
                   response.PostComment == null &&
                   response.PostCommentLikes.MatchesSortedCollection(postCommentLikes,
                                                              matches,
                                                              termTransformer,
                                                              request,
                                                              matchesFilter);
        }
    }
}
