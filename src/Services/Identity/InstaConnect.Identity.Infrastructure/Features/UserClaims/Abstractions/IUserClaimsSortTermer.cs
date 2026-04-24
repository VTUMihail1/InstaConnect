using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimsSortTermer : ISortTermer<UserClaimsSortTerm, UserClaimResponse>;
