using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Posts.Business.Commands.Posts.AddPost;

internal class AddPostCommandHandler : ICommandHandler<AddPostCommand>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly IGetCurrentUserRequestClient _requestClient;

    public AddPostCommandHandler(
        IMapper mapper,
        IPostRepository postRepository,
        IGetCurrentUserRequestClient requestClient)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _requestClient = requestClient;
    }

    public async Task Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var getCurrentUserRequest = _mapper.Map<GetCurrentUserRequest>(request);
        var getCurrentUserResponse = await _requestClient.GetResponse<GetCurrentUserResponse>(getCurrentUserRequest, cancellationToken);

        var post = _mapper.Map<Post>(request);
        _mapper.Map(getCurrentUserResponse.Message, post);
        await _postRepository.AddAsync(post, cancellationToken);
    }
}
