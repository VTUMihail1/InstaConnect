using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Response;
public record EmailConfirmationTokenCollection(ICollection<EmailConfirmationToken> Data);
