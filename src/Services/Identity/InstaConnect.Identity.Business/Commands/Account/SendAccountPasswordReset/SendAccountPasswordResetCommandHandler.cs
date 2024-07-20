﻿using AutoMapper;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Identity.Business.Commands.Account.SendAccountPasswordReset;

public class SendAccountPasswordResetCommandHandler : ICommandHandler<SendAccountPasswordResetCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ITokenRepository _tokenRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public SendAccountPasswordResetCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        ITokenGenerator tokenGenerator,
        ITokenRepository tokenRepository,
        IPublishEndpoint publishEndpoint)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _tokenRepository = tokenRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(SendAccountPasswordResetCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var createAccountTokenModel = _mapper.Map<CreateAccountTokenModel>(existingUser);
        var token = _tokenGenerator.GeneratePasswordResetToken(createAccountTokenModel);
        _tokenRepository.Add(token);

        var userForgotPasswordTokenCreatedEvent = _mapper.Map<UserForgotPasswordTokenCreatedEvent>(token);
        _mapper.Map(existingUser, userForgotPasswordTokenCreatedEvent);
        await _publishEndpoint.Publish(userForgotPasswordTokenCreatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}