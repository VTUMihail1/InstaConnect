using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Models;
using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;

namespace InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenQueryFactory : IEmailConfirmationTokenQueryFactory
{
    public GetAllEmailConfirmationTokensQuerySpecification CreateGetAll(GetAllEmailConfirmationTokensQuery query)
    {
        var parameters = new GetAllEmailConfirmationTokensQueryParameters(query.Filter.Id);

        var specification = new GetAllEmailConfirmationTokensQuerySpecification(
            EmailConfirmationTokenQuerySql.GetAll,
            parameters);

        return specification;
    }

    public GetEmailConfirmationTokenByIdQuerySpecification CreateGetById(string id, string value)
    {
        var parameters = new GetEmailConfirmationTokenByIdQueryParameters(id, value);

        var result = new GetEmailConfirmationTokenByIdQuerySpecification(
            EmailConfirmationTokenQuerySql.GetById,
            parameters);

        return result;
    }
}
