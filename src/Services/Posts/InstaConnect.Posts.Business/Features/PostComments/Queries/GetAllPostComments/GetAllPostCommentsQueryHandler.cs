using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllFilteredPostComments;

internal class GetAllPostCommentsQueryHandler : IQueryHandler<GetAllPostCommentsQuery, PostCommentPaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentReadRepository _postCommentReadRepository;

    public GetAllPostCommentsQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostCommentReadRepository postCommentReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postCommentReadRepository = postCommentReadRepository;
    }

    public async Task<PostCommentPaginationQueryViewModel> Handle(
        GetAllPostCommentsQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostCommentFilteredCollectionReadQuery>(request);

        var postComments = await _postCommentReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentPaginationQueryViewModel>(postComments);

        return response;
    }
}
