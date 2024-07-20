﻿using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Identity.Data.Repositories;

internal class UserClaimRepository : BaseReadRepository<UserClaim>, IUserClaimRepository
{
    public UserClaimRepository(IdentityContext identityContext) : base(identityContext)
    {
    }
}