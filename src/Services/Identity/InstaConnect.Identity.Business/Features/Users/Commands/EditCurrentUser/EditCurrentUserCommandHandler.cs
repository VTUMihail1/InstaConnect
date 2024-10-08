﻿using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Commands.EditCurrentUser;

public class EditCurrentUserCommandHandler : ICommandHandler<EditCurrentUserCommand, UserCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public EditCurrentUserCommandHandler(
        IUnitOfWork unitOfWork,
        IImageHandler imageHandler,
        IEventPublisher eventPublisher,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _imageHandler = imageHandler;
        _eventPublisher = eventPublisher;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<UserCommandViewModel> Handle(
        EditCurrentUserCommand request,
        CancellationToken cancellationToken)
    {
        var existingUserById = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUserById == null)
        {
            throw new UserNotFoundException();
        }

        var existingUserByName = await _userWriteRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingUserById.UserName != request.UserName && existingUserByName != null)
        {
            throw new UserNameAlreadyTakenException();
        }

        _instaConnectMapper.Map(request, existingUserById);

        if (request.ProfileImageFile != null)
        {
            var imageUploadModel = _instaConnectMapper.Map<ImageUploadModel>(request);
            var imageUploadResult = await _imageHandler.UploadAsync(imageUploadModel, cancellationToken);
            _instaConnectMapper.Map(imageUploadResult, existingUserById);
        }

        _userWriteRepository.Update(existingUserById);

        var userUpdatedEvent = _instaConnectMapper.Map<UserUpdatedEvent>(existingUserById);
        await _eventPublisher.PublishAsync(userUpdatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountCommandViewModel = _instaConnectMapper.Map<UserCommandViewModel>(existingUserById);

        return accountCommandViewModel;
    }
}
