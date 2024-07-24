using AutoMapper;
using InstaConnect.Posts.Data.Models.Filters.PostComments;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Read.Business.Queries.PostComments.GetAllFilteredPostComments;

internal class GetAllFilteredPostCommentsQueryHandler : IQueryHandler<GetAllFilteredPostCommentsQuery, ICollection<PostCommentQueryViewModel>>
{
    private readonly IMapper _instaConnectMapper;
    private readonly IPostCommentReadRepository _postCommentRepository;

    public GetAllFilteredPostCommentsQueryHandler(
        IMapper instaConnectMapper,
        IPostCommentReadRepository postCommentRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postCommentRepository = postCommentRepository;
    }

    public async Task<ICollection<PostCommentQueryViewModel>> Handle(GetAllFilteredPostCommentsQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostCommentFilteredCollectionReadQuery>(request);

        var postComments = await _postCommentRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<ICollection<PostCommentQueryViewModel>>(postComments);

        return response;
    }
}
