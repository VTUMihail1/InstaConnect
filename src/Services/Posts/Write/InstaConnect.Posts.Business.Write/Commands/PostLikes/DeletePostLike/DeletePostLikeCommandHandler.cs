﻿using AutoMapper;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.PostLikes;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostLikes.DeletePostLike;

internal class DeletePostLikeCommandHandler : ICommandHandler<DeletePostLikeCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public DeletePostLikeCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        IPostLikeRepository postLikeRepository,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
        _postLikeRepository = postLikeRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Handle(DeletePostLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPostLike = await _postLikeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUser();

        if (currentUserDetails.Id != existingPostLike.UserId)
        {
            throw new AccountForbiddenException();
        }

        _postLikeRepository.Delete(existingPostLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postLikeDeletedEvent = _mapper.Map<PostLikeDeletedEvent>(existingPostLike);
        await _publishEndpoint.Publish(postLikeDeletedEvent, cancellationToken);
    }
}
