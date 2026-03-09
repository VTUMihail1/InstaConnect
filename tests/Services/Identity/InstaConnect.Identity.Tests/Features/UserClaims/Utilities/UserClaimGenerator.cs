namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimGenerator
{
    extension(UserClaim baseUserClaim)
    {
        public ICollection<UserClaim> Generate(IEnumerable<User> users, int numberOfIterations = 3)
        {
            return [baseUserClaim, .. users
               .SelectMany(user =>
                   Enumerable.Range(default, numberOfIterations).Select(_ =>
                   {
                         var userClaim = new UserClaim(
                             new(user.Id, UserClaimDataFaker.GetClaim()),
                             UserClaimDataFaker.GetCreatedAtUtc());

                         user.AddUserClaim(userClaim);
                         userClaim.AddUser(user);

                         return userClaim;
                   }))];
        }
    }
}
