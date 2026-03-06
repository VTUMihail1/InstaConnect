using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Tests.Utilities;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Posts.Application.Features.Users.Abstractions;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostMapper
{
    extension(Post post)
    {
        internal PostId ToIdResponse(
)
        {
            return post.Id;
        }

        internal PostResponse ToFullResponse<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(post.Id,
                       post.UserId,
                       post.Title,
                       post.Content,
                       post.User?.ToFullResponse(),
                       post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                       post.CreatedAtUtc,
                       post.UpdatedAtUtc);
        }

        internal PostResponse ToResponseWithoutUser<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest
        {
            return new(post.Id,
                       post.UserId,
                       post.Title,
                       post.Content,
                       null,
                       post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                       post.CreatedAtUtc,
                       post.UpdatedAtUtc);
        }

        public PostId ToResponse(
            AddPostCommandRequest request)
        {
            return post.ToIdResponse();
        }

        public PostId ToResponse(
            UpdatePostCommandRequest request)
        {
            return post.ToIdResponse();
        }

        public PostResponse ToResponse(
            GetPostByIdQueryRequest request)
        {
            return post.ToFullResponse(request);
        }
    }

    extension(ICollection<Post> posts)
    {
        internal PostCollectionResponse ToFullResponse<TRequest>(
        User user,
        Func<Post, TRequest, bool> filter,
        Func<Post, TRequest, PostResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            var paginator = new Paginator();
            var totalCount = posts.Count(post => filter(post, request));

            return new(user.ToFullResponse(),
                        posts.Filter(post => filter(post, request), request, post => transform(post, request)),
                        request.Page,
                        request.PageSize,
                        totalCount,
                        paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                        paginator.HasPreviousPage(request.Page));
        }

        internal PostCollectionResponse ToResponseWithoutUser<TRequest>(
            Func<Post, TRequest, bool> filter,
            Func<Post, TRequest, PostResponse> transform,
            TRequest request)
            where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
        {
            var paginator = new Paginator();
            var totalCount = posts.Count(post => filter(post, request));

            return new(null,
                       posts.Filter(post => filter(post, request), request, post => transform(post, request)),
                       request.Page,
                       request.PageSize,
                       totalCount,
                       paginator.HasNextPage(request.Page, request.PageSize, totalCount),
                       paginator.HasPreviousPage(request.Page));
        }

        public PostCollectionResponse ToResponse(
            GetAllPostsQueryRequest request)
        {
            return posts.ToResponseWithoutUser(
                (post, request) => post.MatchesFilter(request),
                (post, request) => post.ToFullResponse(request),
                request);
        }

        public PostCollectionResponse ToResponse(
            User user,
            GetAllPostsForUserQueryRequest request)
        {
            return posts.ToFullResponse(
                user,
                (post, request) => post.MatchesFilter(request),
                (post, request) => post.ToResponseWithoutUser(request),
                request);
        }
    }
}
