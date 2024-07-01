using AutoMapper;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Posts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.Posts.AddPost;

internal class AddPostCommandHandler : ICommandHandler<AddPostCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ICurrentUserContext _currentUserContext;

    public AddPostCommandHandler(
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

    public async Task Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var currentUserDetails = _currentUserContext.GetCurrentUser();

        var post = _mapper.Map<Post>(request);
        _mapper.Map(currentUserDetails, post);
        _postRepository.Add(post);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCreatedEvent = _mapper.Map<PostCreatedEvent>(post);
        await _publishEndpoint.Publish(postCreatedEvent, cancellationToken);
    }
}
