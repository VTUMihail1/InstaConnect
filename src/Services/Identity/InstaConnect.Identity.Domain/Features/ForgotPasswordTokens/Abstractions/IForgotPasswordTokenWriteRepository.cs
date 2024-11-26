﻿using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
public interface IForgotPasswordTokenWriteRepository
{
    void Add(ForgotPasswordToken forgotPasswordToken);
    void Delete(ForgotPasswordToken forgotPasswordToken);
    Task<ForgotPasswordToken?> GetByValueAsync(string value, CancellationToken cancellationToken);
}
