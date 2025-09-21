using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Models;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;
public interface IForgotPasswordTokenQueryFactory
{
    GetForgotPasswordTokenByIdQuerySpecification CreateGetById(string id, string value);
}
