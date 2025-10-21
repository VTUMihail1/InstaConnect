using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Responses;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Helpers;

internal class PostCommentCollectionFactory : IPostCommentCollectionFactory
{
    private readonly IPaginator _paginator;

    public PostCommentCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public PostCommentCollection Create(ICollection<PostComment> postComments, int totalCount, PostCommentPaginationQuery pagination)
    {
        var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
        var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

        return new PostCommentCollection(
            postComments,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
