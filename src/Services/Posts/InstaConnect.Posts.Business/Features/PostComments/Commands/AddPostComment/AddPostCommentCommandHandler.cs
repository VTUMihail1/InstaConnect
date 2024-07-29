using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;

internal class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommand, PostCommentCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IPostWriteRepository _postWriteRepository;
    private readonly IPostCommentWriteRepository _postCommentWriteRepository;

    public AddPostCommentCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IPostWriteRepository postWriteRepository,
        IPostCommentWriteRepository postCommentWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _postWriteRepository = postWriteRepository;
        _postCommentWriteRepository = postCommentWriteRepository;
    }

    public async Task<PostCommentCommandViewModel> Handle(
        AddPostCommentCommand request,
        CancellationToken cancellationToken)
    {
        var existingPost = await _postWriteRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var existingUser = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var postComment = _instaConnectMapper.Map<PostComment>(request);
        _postCommentWriteRepository.Add(postComment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentCommandViewModel = _instaConnectMapper.Map<PostCommentCommandViewModel>(request);

        return postCommentCommandViewModel;
    }
}
