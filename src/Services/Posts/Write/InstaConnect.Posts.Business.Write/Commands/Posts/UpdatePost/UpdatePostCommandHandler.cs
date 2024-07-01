using AutoMapper;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Posts;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.Posts.UpdatePost;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ICurrentUserContext _currentUserContext;

    public UpdatePostCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostRepository postRepository,
        IPublishEndpoint publishEndpoint,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _publishEndpoint = publishEndpoint;
        _currentUserContext = currentUserContext;
    }

    public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUser();

        if (currentUserDetails.Id != existingPost.UserId)
        {
            throw new AccountForbiddenException();
        }

        _mapper.Map(request, existingPost);
        _postRepository.Update(existingPost);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postUpdatedEvent = _mapper.Map<PostUpdatedEvent>(existingPost);
        await _publishEndpoint.Publish(postUpdatedEvent, cancellationToken);
    }
}
