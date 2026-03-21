using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
    extension(GetAllPostCommentsQuery query)
    {
        public bool Matches(GetAllPostCommentsQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostCommentsQuery, PostCommentsSortTerm, PostCommentsSortingQuery, GetAllPostCommentsQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllPostCommentsQuery, PostCommentsPaginationQuery, GetAllPostCommentsQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostCommentsQueryRequest request)
        {
            return query.Filter.Id.Matches(request.Id) &&
                   query.Filter.UserName.Matches(request.UserName);
        }
    }

    extension(GetAllPostCommentsForUserQuery query)
    {
        public bool Matches(GetAllPostCommentsForUserQueryRequest request)
        {
            return query.MatchesFilter(request) &&
                   query.MatchesSortable<GetAllPostCommentsForUserQuery, PostCommentsForUserSortTerm, PostCommentsForUserSortingQuery, GetAllPostCommentsForUserQueryRequest>(request) &&
                   query.MatchesPaginatable<GetAllPostCommentsForUserQuery, PostCommentsPaginationQuery, GetAllPostCommentsForUserQueryRequest>(request) &&
                   query.MatchesCurrentUserable(request);
        }

        public bool MatchesFilter(GetAllPostCommentsForUserQueryRequest request)
        {
            return query.Filter.UserId.Matches(request.UserId);
        }
    }

    extension(GetPostCommentByIdQuery query)
    {
        public bool Matches(GetPostCommentByIdQueryRequest request)
        {
            return query.Id.Matches(request.Id, request.CommentId) &&
                   query.MatchesCurrentUserable(request);
        }
    }

    extension(AddPostCommentCommand command)
    {
        public bool Matches(AddPostCommentCommandRequest request)
        {
            return command.Id.Matches(request.Id) &&
                   command.UserId.Matches(request.UserId) &&
                   command.Content == request.Content;
        }
    }

    extension(UpdatePostCommentCommand command)
    {
        public bool Matches(UpdatePostCommentCommandRequest request)
        {
            return command.Id.Matches(request.Id, request.CommentId) &&
                   command.UserId.Matches(request.UserId) &&
                   command.Content == request.Content;
        }
    }

    extension(DeletePostCommentCommand command)
    {
        public bool Matches(DeletePostCommentCommandRequest request)
        {
            return command.Id.Matches(request.Id, request.CommentId) &&
                   command.UserId.Matches(request.UserId);
        }
    }

    extension(AddPostCommentCommandResponse response)
    {
        public bool Matches(PostComment postComment, AddPostCommentCommandRequest request)
        {
            return response.Id.Matches(postComment.Id);
        }
    }

    extension(UpdatePostCommentCommandResponse response)
    {
        public bool Matches(PostComment postComment, UpdatePostCommentCommandRequest request)
        {
            return response.Id.Matches(postComment.Id);
        }
    }

    extension(GetPostCommentByIdQueryResponse response)
    {
        public bool Matches(PostComment postComment, GetPostCommentByIdQueryRequest request)
        {
            return response.PostComment.MatchesFull(postComment, request);
        }
    }

    extension(GetAllPostCommentsQueryResponse response)
    {
        public bool Matches(Post post, ICollection<PostComment> postComments, GetAllPostCommentsQueryRequest request)
        {
            return response.PostCommentCollection.MatchesWithoutUser(
                (res, comment) => res.MatchesWithoutPost(comment, request),
                comment => comment.MatchesFilter(request),
                post,
                postComments,
                request
            );
        }

        public bool Matches(Post post, ICollection<PostComment> postComments, GetAllPostCommentsQueryRequest request, ISortEnumTermTransformer<PostComment> termTransformer)
        {
            return response.PostCommentCollection.MatchesWithoutUser(
                (res, comment) => res.MatchesWithoutPost(comment, request),
                comment => comment.MatchesFilter(request),
                post,
                postComments,
                request,
                termTransformer
            );
        }
    }

    extension(GetAllPostCommentsForUserQueryResponse response)
    {
        public bool Matches(User user, ICollection<PostComment> postComments, GetAllPostCommentsForUserQueryRequest request)
        {
            return response.PostCommentCollection.MatchesWithoutPost(
                (res, comment) => res.MatchesWithoutUser(comment, request),
                comment => comment.MatchesFilter(request),
                user,
                postComments,
                request
            );
        }

        public bool Matches(User user, ICollection<PostComment> postComments, GetAllPostCommentsForUserQueryRequest request, ISortEnumTermTransformer<PostComment> termTransformer)
        {
            return response.PostCommentCollection.MatchesWithoutPost(
                (res, comment) => res.MatchesWithoutUser(comment, request),
                comment => comment.MatchesFilter(request),
                user,
                postComments,
                request,
                termTransformer
            );
        }
    }

    extension(PostComment postComment)
    {
        public bool Matches(AddPostCommentCommandRequest request)
        {
            return postComment.Id.Id.Matches(request.Id) &&
                   postComment.UserId.Matches(request.UserId) &&
                   postComment.Content == request.Content;
        }

        public bool Matches(UpdatePostCommentCommandRequest request)
        {
            return postComment.Id.Matches(request.Id, request.CommentId) &&
                   postComment.UserId.Matches(request.UserId) &&
                   postComment.Content == request.Content;
        }

        public bool MatchesFilter(GetAllPostCommentsQueryRequest request)
        {
            return postComment.Id.Id.Id.EqualsOrdinalIgnoreCase(request.Id) &&
                   postComment.User != null &&
                   postComment.User.Name.Value.StartsWithOrdinalIgnoreCase(request.UserName);
        }

        public bool MatchesFilter(GetAllPostCommentsForUserQueryRequest request)
        {
            return postComment.UserId.Id.EqualsOrdinalIgnoreCase(request.UserId);
        }
    }

    extension(PostCommentIdCommandResponse response)
    {
        public bool Matches(PostCommentId id)
        {
            return id.Matches(response.Id, response.CommentId);
        }
    }

    extension(PostCommentQueryResponse? response)
    {
        public bool MatchesFull<TRequest>(PostComment? postComment, TRequest request)
        where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   postComment != null &&
                   postComment.Id.Matches(response.Id, response.CommentId) &&
                   postComment.UserId.Matches(response.UserId) &&
                   postComment.Content == response.Content &&
                   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
                   postComment.CreatedAtUtc == response.CreatedAtUtc &&
                   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.User.MatchesFull(postComment.User) &&
                   response.Post.MatchesFull(postComment.Post, request);
        }

        public bool MatchesWithoutUser<TRequest>(PostComment? postComment, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   postComment != null &&
                   postComment.Id.Matches(response.Id, response.CommentId) &&
                   postComment.UserId.Matches(response.UserId) &&
                   postComment.Content == response.Content &&
                   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
                   postComment.CreatedAtUtc == response.CreatedAtUtc &&
                   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.User == null &&
                   response.Post.MatchesFull(postComment.Post, request);
        }

        public bool MatchesWithoutPost<TRequest>(PostComment? postComment, TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return response != null &&
                   postComment != null &&
                   postComment.Id.Matches(response.Id, response.CommentId) &&
                   postComment.UserId.Matches(response.UserId) &&
                   postComment.Content == response.Content &&
                   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)) &&
                   postComment.CreatedAtUtc == response.CreatedAtUtc &&
                   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
                   response.User.MatchesFull(postComment.User) &&
                   response.Post == null;
        }
    }

    extension(PostCommentCollectionQueryResponse response)
    {
        public bool MatchesWithoutUser<TRequest>(Func<PostCommentQueryResponse, PostComment, bool> matches, Func<PostComment, bool> matchesFilter, Post post, ICollection<PostComment> postComments, TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
                   response.User == null &&
                   response.Post.MatchesFull(post, request) &&
                   response.PostComments.MatchesCollection(
                       postComments,
                       response => new(new(response.Id), response.CommentId),
                       postComment => postComment.Id,
                       matches,
                       request,
                       matchesFilter
                   );
        }

        public bool MatchesWithoutUser<TRequest>(Func<PostCommentQueryResponse, PostComment, bool> matches, Func<PostComment, bool> matchesFilter, Post post, ICollection<PostComment> postComments, TRequest request, ISortEnumTermTransformer<PostComment> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
                   response.User == null &&
                   response.Post.MatchesFull(post, request) &&
                   response.PostComments.MatchesSortedCollection(
                       postComments,
                       matches,
                       termTransformer,
                       request,
                       matchesFilter
                   );
        }

        public bool MatchesWithoutPost<TRequest>(Func<PostCommentQueryResponse, PostComment, bool> matches, Func<PostComment, bool> matchesFilter, User user, ICollection<PostComment> postComments, TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
                   response.User.MatchesFull(user) &&
                   response.Post == null &&
                   response.PostComments.MatchesCollection(
                       postComments,
                       response => new(new(response.Id), response.CommentId),
                       postComment => postComment.Id,
                       matches,
                       request,
                       matchesFilter
                   );
        }

        public bool MatchesWithoutPost<TRequest>(Func<PostCommentQueryResponse, PostComment, bool> matches, Func<PostComment, bool> matchesFilter, User user, ICollection<PostComment> postComments, TRequest request, ISortEnumTermTransformer<PostComment> termTransformer)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            return response.MatchesCollectionResponse(postComments.Count(matchesFilter), request) &&
                   response.User.MatchesFull(user) &&
                   response.Post == null &&
                   response.PostComments.MatchesSortedCollection(
                       postComments,
                       matches,
                       termTransformer,
                       request,
                       matchesFilter
                   );
        }
    }
}
