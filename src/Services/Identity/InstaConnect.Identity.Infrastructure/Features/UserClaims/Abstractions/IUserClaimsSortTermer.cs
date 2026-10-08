using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimsSortTermer : ISortTermer<UserClaimsSortTerm, UserClaimResponse>;
