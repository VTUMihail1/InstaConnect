namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

internal class AddPostCommandHandler : ICommandHandler<AddPostCommand, AddPostCommandResponse>
{
    private readonly IPostService _postService;
    private readonly IApplicationMapper _applicationMapper;

    public AddPostCommandHandler(
        IPostService postService,
        IApplicationMapper applicationMapper)
    {
        _postService = postService;
        _applicationMapper = applicationMapper;
    }

    public async Task<AddPostCommandResponse> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddPostRequest>(request);
        var post = await _postService.AddAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<AddPostCommandResponse>(post);

        return response;
    }
}
