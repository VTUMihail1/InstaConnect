using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;

internal class AddPostLikeCommandHandler : ICommandHandler<AddPostLikeCommand>
{
    private const string POST_ALREADY_LIKED = "This user has already liked this post";

    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly IRequestClient<GetCurrentUserRequest> _getCurrentUserRequestClient;

    public AddPostLikeCommandHandler(
        IMapper mapper,
        IPostRepository postRepository,
        IPostLikeRepository postLikeRepository,
        IRequestClient<GetCurrentUserRequest> getCurrentUserRequestClient)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _postLikeRepository = postLikeRepository;
        _getCurrentUserRequestClient = getCurrentUserRequestClient;
    }

    public async Task Handle(AddPostLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPost = _postRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var getCurrentUserRequest = _mapper.Map<GetCurrentUserRequest>(request);
        var getCurrentUserResponse = await _getCurrentUserRequestClient.GetResponse<GetCurrentUserResponse>(getCurrentUserRequest, cancellationToken);

        var existingPostLike = _postLikeRepository.GetByUserIdAndPostIdAsync(getCurrentUserResponse.Message.Id, request.PostId, cancellationToken);

        if (existingPostLike == null)
        {
            throw new BadRequestException(POST_ALREADY_LIKED);
        }

        var postLike = _mapper.Map<PostLike>(request);
        _mapper.Map(getCurrentUserResponse, postLike);
        await _postLikeRepository.AddAsync(postLike, cancellationToken);
    }
}
