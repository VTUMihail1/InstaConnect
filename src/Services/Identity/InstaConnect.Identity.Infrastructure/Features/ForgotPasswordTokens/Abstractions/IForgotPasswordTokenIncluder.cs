using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

internal interface IForgotPasswordTokenIncluder : IIncluder<ForgotPasswordToken, IdentityIncludeType, IdentityDestinationType>;
