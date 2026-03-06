using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
    extension(PostLike postLike)
    {
        internal PostLikeId ToIdResponse(
)
        {
            return postLike.Id;
        }

        internal PostLikeResponse ToFullResponse<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(postLike.Id,
                       postLike.User?.ToFullResponse(),
                       postLike.Post?.ToFullResponse(request),
                       postLike.CreatedAtUtc);
        }

        internal PostLikeResponse ToResponseWithoutUser<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(postLike.Id,
                       null,
                       postLike.Post?.ToFullResponse(request),
                       postLike.CreatedAtUtc);
        }

        internal PostLikeResponse ToResponseWithoutPost<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(postLike.Id,
                       postLike.User?.ToFullResponse(),
                       null,
                       postLike.CreatedAtUtc);
        }

        public PostLikeId ToResponse(
            AddPostLikeCommandRequest request)
        {
            return postLike.ToIdResponse();
        }

        public PostLikeResponse ToResponse(
            GetPostLikeByIdQueryRequest request)
        {
            return postLike.ToFullResponse(request);
        }
    }

    extension(ICollection<PostLike> postLikes)
    {
        internal PostLikeCollectionResponse ToResponseWithoutUser<TRequest>(
        Post post,
        Func<PostLike, TRequest, bool> filter,
        Func<PostLike, TRequest, PostLikeResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            var paginator = new Paginator();
            var totalCount = postLikes.Count(postLike => filter(postLike, request));

            return new(post?.ToFullResponse(request),
                       null,
                       postLikes.Filter(postLike => filter(postLike, request), request, postLike => transform(postLike, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        internal PostLikeCollectionResponse ToResponseWithoutPost<TRequest>(
            User user,
            Func<PostLike, TRequest, bool> filter,
            Func<PostLike, TRequest, PostLikeResponse> transform,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            var paginator = new Paginator();
            var totalCount = postLikes.Count(postLike => filter(postLike, request));

            return new(null,
                       user.ToFullResponse(),
                       postLikes.Filter(postLike => filter(postLike, request), request, postLike => transform(postLike, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        public PostLikeCollectionResponse ToResponse(
            Post post,
            GetAllPostLikesQueryRequest request)
        {
            return postLikes.ToResponseWithoutUser(
                post,
                (postLike, request) => postLike.MatchesFilter(request),
                (postLike, request) => postLike.ToResponseWithoutPost(request),
                request);
        }

        public PostLikeCollectionResponse ToResponse(
            User user,
            GetAllPostLikesForUserQueryRequest request)
        {
            return postLikes.ToResponseWithoutPost(
                user,
                (postLike, request) => postLike.MatchesFilter(request),
                (postLike, request) => postLike.ToResponseWithoutUser(request),
                request);
        }
    }
}
