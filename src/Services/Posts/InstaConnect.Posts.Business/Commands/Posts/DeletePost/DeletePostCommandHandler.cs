using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.Posts.DeletePost;

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
            throw new AccountForbiddenException();
        }

        _postWriteRepository.Delete(existingPost);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
