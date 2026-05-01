namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenGenerator
{
	extension(ForgotPasswordToken baseForgotPasswordToken)
	{
		public ICollection<ForgotPasswordToken> Generate(IEnumerable<User> users, int numberOfIterations = 3)
		{
			return [baseForgotPasswordToken, .. users
			   .SelectMany(user =>
				   Enumerable.Range(default, numberOfIterations).Select(_ =>
				   {
					  var forgotPasswordToken = new ForgotPasswordToken(
						  new(user.Id, ForgotPasswordTokenDataFaker.GetValue()),
						  ForgotPasswordTokenDataFaker.GetExpiresAtUtc(),
						  ForgotPasswordTokenDataFaker.GetCreatedAtUtc());

					  user.AddForgotPasswordToken(forgotPasswordToken);
					  forgotPasswordToken.AddUser(user);

					  return forgotPasswordToken;
				   }))];
		}
	}
}
