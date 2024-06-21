using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Business.Commands.Posts.DeletePost;

internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public DeletePostCommandHandler(
        IUnitOfWork unitOfWork,
        IPostRepository postRepository,
        ICurrentUserContext currentUserContext)
    {
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        if (currentUserDetails.Id != existingPost.UserId)
        {
            throw new AccountForbiddenException();
        }

        _postRepository.Delete(existingPost);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
