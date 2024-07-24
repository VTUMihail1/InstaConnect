using AutoMapper;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Posts;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Write.Business.Commands.Posts.DeletePost;

internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostWriteRepository _postRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public DeletePostCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostWriteRepository postRepository,
        IPublishEndpoint publishEndpoint)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        if (request.CurrentUserId != existingPost.UserId)
        {
            throw new AccountForbiddenException();
        }

        _postRepository.Delete(existingPost);

        var postDeletedEvent = _mapper.Map<PostDeletedEvent>(existingPost);
        await _publishEndpoint.Publish(postDeletedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
