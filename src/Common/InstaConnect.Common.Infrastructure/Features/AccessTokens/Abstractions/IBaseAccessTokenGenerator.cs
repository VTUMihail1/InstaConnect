using System.Security.Claims;

using InstaConnect.Common.Domain.Features.AccessTokens.Models;

namespace InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;

public interface IBaseAccessTokenGenerator
{
	public AccessToken Generate(IEnumerable<Claim> claims);
}
