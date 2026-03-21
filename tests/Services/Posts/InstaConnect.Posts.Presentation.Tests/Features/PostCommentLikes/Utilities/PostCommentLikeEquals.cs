using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
    extension(GetAllPostCommentLikesQueryRequest query)
    {
        public bool Matches(GetAllPostCommentLikesApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostCommentLikesQueryRequest, PostCommentLikesSortTerm, GetAllPostCommentLikesApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostCommentLikesApiRequest request)
        {
            return query.Id == request.Id &&
                   query.CommentId == request.CommentId &&
                   query.UserName == request.UserName;
        }
    }

    extension(GetAllPostCommentLikesForUserQueryRequest query)
    {
        public bool Matches(GetAllPostCommentLikesForUserApiRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostCommentLikesForUserQueryRequest, PostCommentLikesForUserSortTerm, GetAllPostCommentLikesForUserApiRequest>(request) &&
                   query.MatchesPaginatable(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostCommentLikesForUserApiRequest request)
        {
            return query.UserId == request.UserId;
        }
    }

    extension(GetPostCommentLikeByIdQueryRequest query)
    {
        public bool Matches(GetPostCommentLikeByIdApiRequest request)
        {
            return query.Id == request.Id &&
                   query.CommentId == request.CommentId &&
                   query.UserId == request.UserId &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddPostCommentLikeCommandRequest command)
    {
        public bool Matches(AddPostCommentLikeApiRequest request)
        {
            return command.Id == request.Id &&
                   command.CommentId == request.CommentId &&
                   command.UserId == request.UserId;
        }
    }

    extension(DeletePostCommentLikeCommandRequest command)
    {
        public bool Matches(DeletePostCommentLikeApiRequest request)
        {
            return command.Id == request.Id &&
                   command.CommentId == request.CommentId &&
                   command.UserId == request.UserId;
        }
    }

    extension(AddPostCommentLikeApiResponse response)
    {
        public bool Matches(
        PostCommentLike postCommentLike,
        AddPostCommentLikeApiRequest request)
        {
            return response.Id.Matches(postCommentLike.Id);
        }
    }

    extension(GetPostCommentLikeByIdApiResponse response)
    {
        public bool Matches(PostCommentLike postCommentLike, GetPostCommentLikeByIdApiRequest request)
        {
            return response.PostCommentLike.MatchesFull(postCommentLike, request);
        }
    }

    extension(GetAllPostCommentLikesApiResponse response)
    {
        public bool Matches(
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request)
        {
            return response.PostCommentLikeCollection.MatchesWithoutUser(
                       (response, postCommentLike) => response.MatchesWithoutPostComment(postCommentLike, request),
                       postCommentLike => postCommentLike.MatchesFilter(request),
                       postComment,
                       postCommentLikes,
                       request);
        }

        public bool Matches(
            PostComment postComment,
            ICollection<PostCommentLike> postCommentLikes,
            GetAllPostCommentLikesApiRequest request,
            ISortEnumTermTransformer<PostCommentLike> termTransformer)
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

    extension(GetAllPostCommentLikesForUserApiResponse response)
    {
        public bool Matches(
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserApiRequest request)
        {
            return response.PostCommentLikeCollection.MatchesWithoutPostComment(
                       (response, postCommentLike) => response.MatchesWithoutUser(postCommentLike, request),
                       postCommentLike => postCommentLike.MatchesFilter(request),
                       user,
                       postCommentLikes,
                       request);
        }

        public bool Matches(
            User user,
            ICollection<PostCommentLike> postCommentLikes,
            GetAllPostCommentLikesForUserApiRequest request,
            ISortEnumTermTransformer<PostCommentLike> termTransformer)
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
        public bool Matches(AddPostCommentLikeApiRequest request)
        {
            return postCommentLike.Id.Matches(request.Id, request.CommentId, request.UserId);
        }

        public bool MatchesFilter(GetAllPostCommentLikesApiRequest request)
        {
            return postCommentLike.Id.CommentId.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
                   postCommentLike.Id.CommentId.CommentId.EqualsOrdinalIgnoreCase(request.CommentId) &&
                   postCommentLike.User != null &&
                   postCommentLike.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
        }

        public bool MatchesFilter(GetAllPostCommentLikesForUserApiRequest request)
        {
            return postCommentLike.Id.UserId.Id.EqualsOrdinalIgnoreCase(request.UserId);
        }
    }

    extension(PostCommentLikeIdApiResponse response)
    {
        public bool Matches(PostCommentLikeId id)
        {
            return id.Matches(response.Id, response.CommentId, response.UserId);
        }
    }

    extension(PostCommentLikeApiResponse? response)
    {
        public bool MatchesFull<TRequest>(PostCommentLike? postCommentLike, TRequest request)
    where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   postCommentLike != null &&
                   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
                   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User.MatchesFull(postCommentLike.User) &&
                   response.PostComment.MatchesFull(postCommentLike.PostComment, request);
        }

        public bool MatchesWithoutUser<TRequest>(PostCommentLike? postCommentLike, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   postCommentLike != null &&
                   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
                   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User == null &&
                   response.PostComment.MatchesFull(postCommentLike.PostComment, request);
        }

        public bool MatchesWithoutPostComment<TRequest>(PostCommentLike? postCommentLike, TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return response != null &&
                   postCommentLike != null &&
                   postCommentLike.Id.Matches(response.Id, response.CommentId, response.UserId) &&
                   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
                   response.User.MatchesFull(postCommentLike.User) &&
                   response.PostComment == null;
        }
    }

    extension(PostCommentLikeCollectionApiResponse response)
    {
        public bool MatchesWithoutUser<TRequest>(
        Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
        Func<PostCommentLike, bool> matchesFilter,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
            Func<PostCommentLike, bool> matchesFilter,
            PostComment postComment,
            ICollection<PostCommentLike> postCommentLikes,
            TRequest request,
            ISortEnumTermTransformer<PostCommentLike> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
            Func<PostCommentLike, bool> matchesFilter,
            User user,
            ICollection<PostCommentLike> postCommentLikes,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
            Func<PostCommentLikeApiResponse, PostCommentLike, bool> matches,
            Func<PostCommentLike, bool> matchesFilter,
            User user,
            ICollection<PostCommentLike> postCommentLikes,
            TRequest request,
            ISortEnumTermTransformer<PostCommentLike> termTransformer)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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
