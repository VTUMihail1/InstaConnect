﻿using InstaConnect.Identity.Business.Features.Accounts.Abstractions;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;

public class RegisterAccountCommandHandler : ICommandHandler<RegisterAccountCommand, AccountCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IEmailConfirmationTokenPublisher _emailConfirmationTokenPublisher;

    public RegisterAccountCommandHandler(
        IUnitOfWork unitOfWork,
        IImageHandler imageHandler,
        IPasswordHasher passwordHasher,
        IEventPublisher eventPublisher,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IEmailConfirmationTokenPublisher emailConfirmationTokenPublisher)
    {
        _unitOfWork = unitOfWork;
        _imageHandler = imageHandler;
        _passwordHasher = passwordHasher;
        _eventPublisher = eventPublisher;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _emailConfirmationTokenPublisher = emailConfirmationTokenPublisher;
    }

    public async Task<AccountCommandViewModel> Handle(
        RegisterAccountCommand request,
        CancellationToken cancellationToken)
    {
        var existingEmailUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingEmailUser != null)
        {
            throw new AccountEmailAlreadyTakenException();
        }

        var existingNameUser = await _userWriteRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingNameUser != null)
        {
            throw new AccountUsernameAlreadyTakenException();
        }

        var passwordHash = _passwordHasher.Hash(request.Password);
        var user = _instaConnectMapper.Map<User>((passwordHash, request));

        if (request.ProfileImage != null)
        {
            var imageUploadModel = _instaConnectMapper.Map<ImageUploadModel>(request);
            var imageUploadResult = await _imageHandler.UploadAsync(imageUploadModel, cancellationToken);

            _instaConnectMapper.Map(imageUploadResult, user);
        }

        _userWriteRepository.Add(user);

        var userCreatedEvent = _instaConnectMapper.Map<UserCreatedEvent>(user);
        await _eventPublisher.PublishAsync(userCreatedEvent, cancellationToken);

        var createEmailConfirmationTokenModel = _instaConnectMapper.Map<CreateEmailConfirmationTokenModel>(user);
        await _emailConfirmationTokenPublisher.PublishEmailConfirmationTokenAsync(createEmailConfirmationTokenModel, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountCommandViewModel = _instaConnectMapper.Map<AccountCommandViewModel>(user);

        return accountCommandViewModel;
    }
}
