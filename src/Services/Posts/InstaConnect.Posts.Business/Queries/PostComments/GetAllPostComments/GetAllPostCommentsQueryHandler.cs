using AutoMapper;
using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Posts.Data.Models.Filters.PostComments;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetAllPostComments;

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
