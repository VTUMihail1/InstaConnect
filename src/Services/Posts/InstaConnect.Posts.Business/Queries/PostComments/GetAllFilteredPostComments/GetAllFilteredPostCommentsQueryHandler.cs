using AutoMapper;
using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Posts.Data.Models.Filters.PostComments;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetAllFilteredPostComments;

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
