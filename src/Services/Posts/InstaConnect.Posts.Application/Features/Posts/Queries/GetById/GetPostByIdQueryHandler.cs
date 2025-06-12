using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

internal class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, GetPostByIdQueryResponse>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostReadRepository _postReadRepository;

    public GetPostByIdQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostReadRepository postReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postReadRepository = postReadRepository;
    }

    public async Task<GetPostByIdQueryResponse> Handle(
        GetPostByIdQuery request,
        CancellationToken cancellationToken)
    {
        var post = await _postReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        var response = _instaConnectMapper.Map<GetPostByIdQueryResponse>(post);

        return response;
    }
}
