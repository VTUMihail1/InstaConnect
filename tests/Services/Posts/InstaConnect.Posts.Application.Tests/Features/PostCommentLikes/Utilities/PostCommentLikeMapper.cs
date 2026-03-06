using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMapper
{
    extension(PostCommentLike postCommentLike)
    {
        internal PostCommentLikeId ToIdResponse()
        {
            return postCommentLike.Id;
        }

        internal PostCommentLikeResponse ToFullResponse<TRequest>(TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(postCommentLike.Id,
                       postCommentLike.User?.ToFullResponse(),
                       postCommentLike.PostComment?.ToFullResponse(request),
                       postCommentLike.CreatedAtUtc);
        }

        internal PostCommentLikeResponse ToResponseWithoutUser<TRequest>(TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(postCommentLike.Id,
                       null,
                       postCommentLike.PostComment?.ToFullResponse(request),
                       postCommentLike.CreatedAtUtc);
        }

        internal PostCommentLikeResponse ToResponseWithoutPostComment<TRequest>(TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(postCommentLike.Id,
                       postCommentLike.User?.ToFullResponse(),
                       null,
                       postCommentLike.CreatedAtUtc);
        }

        public PostCommentLikeId ToResponse(AddPostCommentLikeCommandRequest request)
        {
            return postCommentLike.ToIdResponse();
        }

        public PostCommentLikeResponse ToResponse(GetPostCommentLikeByIdQueryRequest request)
        {
            return postCommentLike.ToFullResponse(request);
        }
    }

    extension(ICollection<PostCommentLike> postCommentLikes)
    {
        internal PostCommentLikeCollectionResponse ToResponseWithoutUser<TRequest>(
            PostComment postComment,
            Func<PostCommentLike, TRequest, bool> filter,
            Func<PostCommentLike, TRequest, PostCommentLikeResponse> transform,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            var paginator = new Paginator();
            var totalCount = postCommentLikes.Count(postCommentLike => filter(postCommentLike, request));

            return new(postComment.ToFullResponse(request),
                       null,
                       postCommentLikes.Filter(postCommentLike => filter(postCommentLike, request), request, postCommentLike => transform(postCommentLike, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        internal PostCommentLikeCollectionResponse ToResponseWithoutPostComment<TRequest>(
            User user,
            Func<PostCommentLike, TRequest, bool> filter,
            Func<PostCommentLike, TRequest, PostCommentLikeResponse> transform,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            var paginator = new Paginator();
            var totalCount = postCommentLikes.Count(postCommentLike => filter(postCommentLike, request));

            return new(null,
                       user.ToFullResponse(),
                       postCommentLikes.Filter(postCommentLike => filter(postCommentLike, request), request, postCommentLike => transform(postCommentLike, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        public PostCommentLikeCollectionResponse ToResponse(
            PostComment postComment,
            GetAllPostCommentLikesQueryRequest request)
        {
            return postCommentLikes.ToResponseWithoutUser(postComment,
                                                          (postCommentLike, request) => postCommentLike.MatchesFilter(request),
                                                          (postCommentLike, request) => postCommentLike.ToResponseWithoutPostComment(request),
                                                          request);
        }

        public PostCommentLikeCollectionResponse ToResponse(
            User user,
            GetAllPostCommentLikesForUserQueryRequest request)
        {
            return postCommentLikes.ToResponseWithoutPostComment(user,
                                                                 (postCommentLike, request) => postCommentLike.MatchesFilter(request),
                                                                 (postCommentLike, request) => postCommentLike.ToResponseWithoutUser(request),
                                                                 request);
        }
    }
}
