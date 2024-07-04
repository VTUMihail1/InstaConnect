using AutoMapper;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Posts.Write.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.PostComments;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Write.Business.Commands.PostComments.AddPostComment;

internal class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IPostCommentRepository _postCommentRepository;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddPostCommentCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostRepository postRepository,
        IPublishEndpoint publishEndpoint,
        IPostCommentRepository postCommentRepository,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _publishEndpoint = publishEndpoint;
        _postCommentRepository = postCommentRepository;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task Handle(AddPostCommentCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);
        var getUserByIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

        if (getUserByIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var postComment = _mapper.Map<PostComment>(request);
        _postCommentRepository.Add(postComment);

        var postCommentCreatedEvent = _mapper.Map<PostCommentCreatedEvent>(postComment);
        await _publishEndpoint.Publish(postCommentCreatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
