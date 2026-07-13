using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenEquals
{
	extension(SessionToken response)
	{
		public bool Matches(RefreshToken refreshToken, IssueRefreshTokenCommand command)
		{
			return response.Matches(refreshToken);
		}

		public bool Matches(RefreshToken refreshToken, RotateRefreshTokenCommand command)
		{
			return response.Matches(refreshToken);
		}

		private bool Matches(RefreshToken refreshToken)
		{
			return response.Id.Matches(refreshToken.Id) &&
				   response.AccessToken.Matches() &&
				   response.ExpiresAtUtc == refreshToken.ExpiresAtUtc;
		}
	}

	extension(RefreshToken refreshToken)
	{
		public bool Matches(IssueRefreshTokenCommand command, IPasswordHasher passwordHasher)
		{
			return refreshToken.User!.Name.Matches(command.Name) &&
				   passwordHasher.IsMatch(command.Password, refreshToken.User.PasswordHash);
		}

		public bool Matches(RotateRefreshTokenCommand command)
		{
			return refreshToken.Id.Id.Matches(command.Id.Id) &&
				   refreshToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace();
		}
	}

	extension(UserInclude p)
	{
		public bool Matches(IssueRefreshTokenCommand command, UserInclude include)
		{
			return p.Matches(include);
		}

		public bool Matches(RotateRefreshTokenCommand command, UserInclude include)
		{
			return p.Matches(include);
		}
	}
}
