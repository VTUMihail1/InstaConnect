using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenIncludeProperty : IIncludeProperty<ForgotPasswordToken>
{
    public ForgotPasswordTokenIncludeProperty IncludeProperty { get; }
}
