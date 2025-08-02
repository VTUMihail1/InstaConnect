using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;

internal class GetAllPostCommentsQueryHandler : IQueryHandler<GetAllPostCommentsQueryRequest, GetAllPostCommentsQueryResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentService _postCommentService;

    public GetAllPostCommentsQueryHandler(
        IApplicationMapper applicationMapper,
        IPostCommentService postCommentService)
    {
        _applicationMapper = applicationMapper;
        _postCommentService = postCommentService;
    }

    public async Task<GetAllPostCommentsQueryResponse> Handle(
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetAllPostCommentsQuery>(request);
        var collection = await _postCommentService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllPostCommentsQueryResponse>(collection);

        return response;
    }
}
