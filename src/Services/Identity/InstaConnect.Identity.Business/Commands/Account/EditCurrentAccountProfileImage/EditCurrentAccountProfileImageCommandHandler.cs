using AutoMapper;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Identity.Business.Commands.Account.EditCurrentAccount;

public class EditCurrentAccountProfileImageCommandHandler : ICommandHandler<EditCurrentAccountProfileImageCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageHandler _imageHandler;
    private readonly IUserRepository _userRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public EditCurrentAccountProfileImageCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IImageHandler imageHandler,
        IUserRepository userRepository,
        IPublishEndpoint publishEndpoint)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _imageHandler = imageHandler;
        _userRepository = userRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(EditCurrentAccountProfileImageCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var imageUploadModel = _mapper.Map<ImageUploadModel>(request);
        var imageUploadResult = await _imageHandler.UploadAsync(imageUploadModel, cancellationToken);

        _mapper.Map(imageUploadResult, existingUser);
        _userRepository.Update(existingUser);

        var userUpdatedEvent = _mapper.Map<UserUpdatedEvent>(existingUser);
        await _publishEndpoint.Publish(userUpdatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
