using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
    extension(PostComment postComment)
    {
        internal PostCommentIdCommandResponse ToIdResponse(
)
        {
            return new(postComment.Id.Id.Id, postComment.Id.CommentId);
        }

        internal PostCommentQueryResponse ToFullResponse<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return new(postComment.Id.Id.Id,
                       postComment.Id.CommentId,
                       postComment.UserId.Id,
                       postComment.Content,
                       postComment.User?.ToFullResponse(),
                       postComment.Post?.ToFullResponse(request),
                       postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                       postComment.CreatedAtUtc,
                       postComment.UpdatedAtUtc);
        }

        internal PostCommentQueryResponse ToResponseWithoutUser<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return new(postComment.Id.Id.Id,
                       postComment.Id.CommentId,
                       postComment.UserId.Id,
                       postComment.Content,
                       null,
                       postComment.Post?.ToFullResponse(request),
                       postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                       postComment.CreatedAtUtc,
                       postComment.UpdatedAtUtc);
        }

        internal PostCommentQueryResponse ToResponseWithoutPost<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return new(postComment.Id.Id.Id,
                       postComment.Id.CommentId,
                       postComment.UserId.Id,
                       postComment.Content,
                       postComment.User?.ToFullResponse(),
                       null,
                       postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                       postComment.CreatedAtUtc,
                       postComment.UpdatedAtUtc);
        }

        public AddPostCommentCommandResponse ToResponse(
            AddPostCommentApiRequest request)
        {
            return new(postComment.ToIdResponse());
        }

        public UpdatePostCommentCommandResponse ToResponse(
            UpdatePostCommentApiRequest request)
        {
            return new(postComment.ToIdResponse());
        }

        public GetPostCommentByIdQueryResponse ToResponse(
            GetPostCommentByIdApiRequest request)
        {
            return new(postComment.ToFullResponse(request));
        }
    }

    extension(ICollection<PostComment> postComments)
    {
        internal PostCommentCollectionQueryResponse ToResponseWithoutUser<TRequest>(
        Post post,
        Func<PostComment, TRequest, bool> filter,
        Func<PostComment, TRequest, PostCommentQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            var paginator = new Paginator();
            var totalCount = postComments.Count(postComment => filter(postComment, request));

            return new(post.ToFullResponse(request),
                       null,
                       postComments.Filter(postComment => filter(postComment, request), request, postComment => transform(postComment, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        internal PostCommentCollectionQueryResponse ToResponseWithoutPost<TRequest>(
            User user,
            Func<PostComment, TRequest, bool> filter,
            Func<PostComment, TRequest, PostCommentQueryResponse> transform,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
        {
            var paginator = new Paginator();
            var totalCount = postComments.Count(postComment => filter(postComment, request));

            return new(null,
                       user.ToFullResponse(),
                       postComments.Filter(postComment => filter(postComment, request), request, postComment => transform(postComment, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        public GetAllPostCommentsQueryResponse ToResponse(
            Post post,
            GetAllPostCommentsApiRequest request)
        {
            return new(postComments.ToResponseWithoutUser(post,
                                                          (postComment, request) => postComment.MatchesFilter(request),
                                                          (postComment, request) => postComment.ToResponseWithoutPost(request),
                                                          request));
        }

        public GetAllPostCommentsForUserQueryResponse ToResponse(
            User user,
            GetAllPostCommentsForUserApiRequest request)
        {
            return new(postComments.ToResponseWithoutPost(user,
                                                          (postComment, request) => postComment.MatchesFilter(request),
                                                          (postComment, request) => postComment.ToResponseWithoutUser(request),
                                                          request));
        }
    }
}
