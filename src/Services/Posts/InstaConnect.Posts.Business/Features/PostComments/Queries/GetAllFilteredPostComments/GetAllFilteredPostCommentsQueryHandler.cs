using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllFilteredPostComments;

internal class GetAllFilteredPostCommentsQueryHandler : IQueryHandler<GetAllFilteredPostCommentsQuery, PostCommentPaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentReadRepository _postCommentReadRepository;

    public GetAllFilteredPostCommentsQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostCommentReadRepository postCommentReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postCommentReadRepository = postCommentReadRepository;
    }

    public async Task<PostCommentPaginationQueryViewModel> Handle(
        GetAllFilteredPostCommentsQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostCommentFilteredCollectionReadQuery>(request);

        var postComments = await _postCommentReadRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentPaginationQueryViewModel>(postComments);

        return response;
    }
}
