using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Read.Business.Queries.PostComments.GetAllPostComments;

internal class GetAllPostCommentsQueryHandler : IQueryHandler<GetAllPostCommentsQuery, ICollection<PostCommentQueryViewModel>>
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

    public async Task<ICollection<PostCommentQueryViewModel>> Handle(GetAllPostCommentsQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _instaConnectMapper.Map<CollectionReadQuery>(request);

        var postComments = await _postCommentRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<ICollection<PostCommentQueryViewModel>>(postComments);

        return response;
    }
}
