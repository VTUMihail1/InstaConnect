﻿namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

internal class AddPostCommandHandler : ICommandHandler<AddPostCommand, PostCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostWriteRepository _postWriteRepository;
    private readonly IUserWriteRepository _userWriteRepository;

    public AddPostCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IPostWriteRepository postWriteRepository,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _postWriteRepository = postWriteRepository;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<PostCommandViewModel> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var post = _instaConnectMapper.Map<Post>(request);
        _postWriteRepository.Add(post);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentViewModel = _instaConnectMapper.Map<PostCommandViewModel>(post);

        return postCommentViewModel;
    }
}
