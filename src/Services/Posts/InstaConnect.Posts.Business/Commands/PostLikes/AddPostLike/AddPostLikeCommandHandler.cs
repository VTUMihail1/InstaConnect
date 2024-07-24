using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Write.Business.Commands.PostLikes.AddPostLike;

internal class AddPostLikeCommandHandler : ICommandHandler<AddPostLikeCommand, PostLikeCommandViewModel>
{
    private const string POST_ALREADY_LIKED = "This user has already liked this post";

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostWriteRepository _postRepository;
    private readonly IPostLikeWriteRepository _postLikeRepository;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddPostLikeCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostWriteRepository postRepository,
        IPostLikeWriteRepository postLikeRepository,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _postLikeRepository = postLikeRepository;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task<PostLikeCommandViewModel> Handle(AddPostLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPost = _postRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);
        var getUserByIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

        if (getUserByIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var existingPostLike = _postLikeRepository.GetByUserIdAndPostIdAsync(request.CurrentUserId, request.PostId, cancellationToken);

        if (existingPostLike == null)
        {
            throw new BadRequestException(POST_ALREADY_LIKED);
        }

        var postLike = _mapper.Map<PostLike>(request);
        _postLikeRepository.Add(postLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postLikeCommandViewModel = _mapper.Map<PostLikeCommandViewModel>(postLike);

        return postLikeCommandViewModel;
    }
}
