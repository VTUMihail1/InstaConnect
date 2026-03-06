using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostMapper
{
    extension(Post post)
    {
        internal PostIdCommandResponse ToIdResponse(
)
        {
            return new(post.Id.Id);
        }

        internal PostQueryResponse ToFullResponse<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return new(post.Id.Id,
                       post.UserId.Id,
                       post.Title,
                       post.Content,
                       post.User?.ToFullResponse(),
                       post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                       post.CreatedAtUtc,
                       post.UpdatedAtUtc);
        }

        internal PostQueryResponse ToResponseWithoutUser<TRequest>(
            TRequest request)
            where TRequest : ICurrentUserableApiRequest
        {
            return new(post.Id.Id,
                       post.UserId.Id,
                       post.Title,
                       post.Content,
                       null,
                       post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUserId)),
                       post.CreatedAtUtc,
                       post.UpdatedAtUtc);
        }

        public AddPostCommandResponse ToResponse(
            AddPostApiRequest request)
        {
            return new(post.ToIdResponse());
        }

        public UpdatePostCommandResponse ToResponse(
            UpdatePostApiRequest request)
        {
            return new(post.ToIdResponse());
        }

        public GetPostByIdQueryResponse ToResponse(
            GetPostByIdApiRequest request)
        {
            return new(post.ToFullResponse(request));
        }
    }

    extension(ICollection<Post> posts)
    {
        internal PostCollectionQueryResponse ToFullResponse<TRequest>(
        User user,
        Func<Post, TRequest, bool> filter,
        Func<Post, TRequest, PostQueryResponse> transform,
        TRequest request)
        where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

        internal PostCollectionQueryResponse ToResponseWithoutUser<TRequest>(
            Func<Post, TRequest, bool> filter,
            Func<Post, TRequest, PostQueryResponse> transform,
            TRequest request)
            where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

        public GetAllPostsQueryResponse ToResponse(
            GetAllPostsApiRequest request)
        {
            return new(posts.ToResponseWithoutUser((post, request) => post.MatchesFilter(request),
                                                   (post, request) => post.ToFullResponse(request),
                                                   request));
        }

        public GetAllPostsForUserQueryResponse ToResponse(
            User user,
            GetAllPostsForUserApiRequest request)
        {
            return new(posts.ToFullResponse(user,
                                            (post, request) => post.MatchesFilter(request),
                                            (post, request) => post.ToResponseWithoutUser(request),
                                            request));
        }
    }
}
