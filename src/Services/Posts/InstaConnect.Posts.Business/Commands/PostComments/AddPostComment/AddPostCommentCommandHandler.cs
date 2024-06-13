using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;

internal class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IPostCommentRepository _postCommentRepository;

    public AddPostCommentCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostRepository postRepository,
        ICurrentUserContext currentUserContext,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _currentUserContext = currentUserContext;
        _postCommentRepository = postCommentRepository;
    }

    public async Task Handle(AddPostCommentCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        var existingPostComment = await _postCommentRepository.GetByIdAsync(request.PostCommentId, cancellationToken);

        if (request.PostCommentId != null && existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();
        var postComment = _mapper.Map<PostComment>(request);
        _mapper.Map(currentUserDetails, postComment);
        _postCommentRepository.Add(postComment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
