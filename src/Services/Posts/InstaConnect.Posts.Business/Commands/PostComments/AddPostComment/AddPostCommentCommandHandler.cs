using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;

internal class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommand>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly IPostCommentRepository _postCommentRepository;
    private readonly IRequestClient<GetCurrentUserRequest> _getCurrentUserRequestClient;

    public AddPostCommentCommandHandler(
        IMapper mapper,
        IPostRepository postRepository,
        IPostCommentRepository postCommentRepository,
        IRequestClient<GetCurrentUserRequest> getCurrentUserRequestClient)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _postCommentRepository = postCommentRepository;
        _getCurrentUserRequestClient = getCurrentUserRequestClient;
    }

    public async Task Handle(AddPostCommentCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        var getCurrentUserRequest = _mapper.Map<GetCurrentUserRequest>(request);
        var getCurrentUserResponse = await _getCurrentUserRequestClient.GetResponse<CurrentUserDetails>(getCurrentUserRequest, cancellationToken);

        var existingPostComment = await _postCommentRepository.GetByIdAsync(request.PostCommentId, cancellationToken);

        if (request.PostCommentId != null && existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var postComment = _mapper.Map<PostComment>(request);
        _mapper.Map(getCurrentUserResponse.Message, postComment);
        await _postCommentRepository.AddAsync(postComment, cancellationToken);
    }
}
