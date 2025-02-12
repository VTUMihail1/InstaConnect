using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Abstract;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

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
        var filteredCollectionQuery = _instaConnectMapper.Map<PostCommentCollectionReadQuery>(request);

        var postComments = await _postCommentReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentPaginationQueryViewModel>(postComments);

        return response;
    }
}
