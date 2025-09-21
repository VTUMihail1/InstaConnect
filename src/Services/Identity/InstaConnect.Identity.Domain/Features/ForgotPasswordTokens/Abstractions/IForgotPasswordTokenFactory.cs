using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;

using System;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenFactory
{
    public ForgotPasswordToken Create(string id);
}
