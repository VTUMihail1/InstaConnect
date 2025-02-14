using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand, PostCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostWriteRepository _postWriteRepository;

    public UpdatePostCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IPostWriteRepository postWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _postWriteRepository = postWriteRepository;
    }

    public async Task<PostCommandViewModel> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        if (request.CurrentUserId != existingPost.UserId)
        {
            throw new UserForbiddenException();
        }

        _instaConnectMapper.Map(request, existingPost);
        _postWriteRepository.Update(existingPost);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentViewModel = _instaConnectMapper.Map<PostCommandViewModel>(existingPost);

        return postCommentViewModel;
    }
}
