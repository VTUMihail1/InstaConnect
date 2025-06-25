using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

internal class GetAllPostCommentsQueryHandler : IQueryHandler<GetAllPostCommentsQuery, PostCommentPaginationQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentService _postCommentService;
    private readonly IPostReadRepository _postReadRepository;

    public GetAllPostCommentsQueryHandler(
        IApplicationMapper applicationMapper,
        IPostCommentService postCommentService,
        IPostReadRepository postReadRepository)
    {
        _applicationMapper = applicationMapper;
        _postCommentService = postCommentService;
        _postReadRepository = postReadRepository;
    }

    public async Task<PostCommentPaginationQueryViewModel> Handle(
        GetAllPostCommentsQuery request,
        CancellationToken cancellationToken)
    {
        var existingPost = await _postReadRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var filteredCollectionQuery = _applicationMapper.Map<PostCommentCollectionReadQuery>(request);

        var postComments = await _postCommentService.GetAllAsync(existingPost, filteredCollectionQuery, cancellationToken);
        var response = _applicationMapper.Map<PostCommentPaginationQueryViewModel>(postComments);

        return response;
    }
}
