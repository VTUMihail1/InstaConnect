using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Models;
using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenQueryFactory : IForgotPasswordTokenQueryFactory
{
    public GetForgotPasswordTokenByIdQuerySpecification CreateGetById(string id, string value)
    {
        var parameters = new GetForgotPasswordTokenByIdQueryParameters(id, value);

        var result = new GetForgotPasswordTokenByIdQuerySpecification(
            ForgotPasswordTokenQuerySql.GetById,
            parameters);

        return result;
    }
}
