using AutoMapper;
using InstaConnect.Posts.Data.Write.Abstract;
using InstaConnect.Posts.Data.Write.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Posts;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Write.Commands.Posts.AddPost;

internal class AddPostCommandHandler : ICommandHandler<AddPostCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddPostCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostRepository postRepository,
        IPublishEndpoint publishEndpoint,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _publishEndpoint = publishEndpoint;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);
        var getUserByIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

        if (getUserByIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var post = _mapper.Map<Post>(request);
        _postRepository.Add(post);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCreatedEvent = _mapper.Map<PostCreatedEvent>(post);
        await _publishEndpoint.Publish(postCreatedEvent, cancellationToken);
    }
}
