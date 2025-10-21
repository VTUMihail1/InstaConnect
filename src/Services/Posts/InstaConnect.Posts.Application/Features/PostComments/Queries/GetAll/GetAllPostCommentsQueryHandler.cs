using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;

internal class GetAllPostCommentsQueryHandler : IQueryHandler<GetAllPostCommentsQueryRequest, GetAllPostCommentsQueryResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentService _postCommentService;
    private readonly IPostCommentIncludeQueryBuilderFactory _postCommentIncludeQueryBuilderFactory;

    public GetAllPostCommentsQueryHandler(
        IApplicationMapper applicationMapper,
        IPostCommentService postCommentService,
        IPostCommentIncludeQueryBuilderFactory postCommentIncludeQueryBuilderFactory)
    {
        _applicationMapper = applicationMapper;
        _postCommentService = postCommentService;
        _postCommentIncludeQueryBuilderFactory = postCommentIncludeQueryBuilderFactory;
    }

    public async Task<GetAllPostCommentsQueryResponse> Handle(
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _postCommentIncludeQueryBuilderFactory.Create().WithUser().Build();
        var serviceRequest = _applicationMapper.Map<GetAllPostCommentsQuery>(request).AddInclude(include);
        var collection = await _postCommentService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllPostCommentsQueryResponse>(collection);

        return response;
    }
}
