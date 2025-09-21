using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Models;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;
public interface IEmailConfirmationTokenQueryFactory
{
    GetAllEmailConfirmationTokensQuerySpecification CreateGetAll(GetAllEmailConfirmationTokensQuery query);

    GetEmailConfirmationTokenByIdQuerySpecification CreateGetById(string id, string value);
}
