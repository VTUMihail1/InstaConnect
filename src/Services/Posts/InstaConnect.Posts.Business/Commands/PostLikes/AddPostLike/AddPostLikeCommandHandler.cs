using AutoMapper;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;

internal class AddPostLikeCommandHandler : ICommandHandler<AddPostLikeCommand>
{
    private const string POST_ALREADY_LIKED = "This user has already liked this post";

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public AddPostLikeCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostRepository postRepository,
        IPostLikeRepository postLikeRepository,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _postLikeRepository = postLikeRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Handle(AddPostLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPost = _postRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        var existingPostLike = _postLikeRepository.GetByUserIdAndPostIdAsync(currentUserDetails.Id!, request.PostId, cancellationToken);

        if (existingPostLike == null)
        {
            throw new BadRequestException(POST_ALREADY_LIKED);
        }

        var postLike = _mapper.Map<PostLike>(request);
        _mapper.Map(currentUserDetails, postLike);
        _postLikeRepository.Add(postLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
