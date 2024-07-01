﻿using AutoMapper;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.PostComments;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;

internal class UpdatePostCommentCommandHandler : ICommandHandler<UpdatePostCommentCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IPostCommentRepository _postCommentRepository;

    public UpdatePostCommentCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        ICurrentUserContext currentUserContext,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
        _currentUserContext = currentUserContext;
        _postCommentRepository = postCommentRepository;
    }

    public async Task Handle(UpdatePostCommentCommand request, CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUser();

        if (currentUserDetails.Id != existingPostComment.UserId)
        {
            throw new AccountForbiddenException();
        }

        _mapper.Map(request, existingPostComment);
        _postCommentRepository.Update(existingPostComment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentUpdatedEvent = _mapper.Map<PostCommentUpdatedEvent>(existingPostComment);
        await _publishEndpoint.Publish(postCommentUpdatedEvent, cancellationToken);
    }
}
