using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllPostComments;

internal class GetAllPostCommentsQueryHandler : IQueryHandler<GetAllPostCommentsQuery, PostCommentPaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentReadRepository _postCommentRepository;

    public GetAllPostCommentsQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostCommentReadRepository postCommentRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postCommentRepository = postCommentRepository;
    }

    public async Task<PostCommentPaginationQueryViewModel> Handle(
        GetAllPostCommentsQuery request,
        CancellationToken cancellationToken)
    {
        var collectionQuery = _instaConnectMapper.Map<PostCommentCollectionReadQuery>(request);

        var postComments = await _postCommentRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentPaginationQueryViewModel>(postComments);

        return response;
    }
}
