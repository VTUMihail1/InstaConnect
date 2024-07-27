using AutoMapper;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Identity.Business.Commands.Account.EditCurrentAccount;

public class EditCurrentAccountProfileImageCommandHandler : ICommandHandler<EditCurrentAccountProfileImageCommand, AccountCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public EditCurrentAccountProfileImageCommandHandler(
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

    public async Task<AccountCommandViewModel> Handle(
        EditCurrentAccountProfileImageCommand request, 
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var imageUploadModel = _instaConnectMapper.Map<ImageUploadModel>(request);
        var imageUploadResult = await _imageHandler.UploadAsync(imageUploadModel, cancellationToken);

        _instaConnectMapper.Map(imageUploadResult, existingUser);
        _userWriteRepository.Update(existingUser);

        var userUpdatedEvent = _instaConnectMapper.Map<UserUpdatedEvent>(existingUser);
        await _eventPublisher.PublishAsync(userUpdatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accountCommandViewModel = _instaConnectMapper.Map<AccountCommandViewModel>(existingUser);

        return accountCommandViewModel;
    }
}
