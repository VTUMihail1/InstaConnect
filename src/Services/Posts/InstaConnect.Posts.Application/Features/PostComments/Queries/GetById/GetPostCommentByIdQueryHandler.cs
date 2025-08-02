using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;

internal class GetPostCommentByIdQueryHandler : IQueryHandler<GetPostCommentByIdQueryRequest, GetPostCommentByIdQueryResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentService _postCommentService;

    public GetPostCommentByIdQueryHandler(
        IApplicationMapper applicationMapper,
        IPostCommentService postCommentService)
    {
        _applicationMapper = applicationMapper;
        _postCommentService = postCommentService;
    }

    public async Task<GetPostCommentByIdQueryResponse> Handle(
        GetPostCommentByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetPostCommentByIdQuery>(request);
        var postComment = await _postCommentService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetPostCommentByIdQueryResponse>(postComment);

        return response;
    }
}
