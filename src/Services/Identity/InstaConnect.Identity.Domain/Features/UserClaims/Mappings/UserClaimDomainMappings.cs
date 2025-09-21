using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using Mapster;

namespace InstaConnect.Users.Domain.Features.Users.Mappings;

internal class UserClaimDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, GetAllUserClaimsQuery>()
            .ConstructUsing(uc => new(
                new(uc.Id)));
    }
}
