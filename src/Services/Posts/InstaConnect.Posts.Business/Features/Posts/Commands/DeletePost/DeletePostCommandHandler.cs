using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Posts.Business.Features.Posts.Commands.DeletePost;

internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostWriteRepository _postWriteRepository;

    public DeletePostCommandHandler(
        IUnitOfWork unitOfWork,
        IPostWriteRepository postWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _postWriteRepository = postWriteRepository;
    }

    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
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

        _postWriteRepository.Delete(existingPost);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
