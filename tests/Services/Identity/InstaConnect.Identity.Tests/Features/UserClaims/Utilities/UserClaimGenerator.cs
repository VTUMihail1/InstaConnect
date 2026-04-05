namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimGenerator
{
    extension(UserClaim baseUserClaim)
    {
        public ICollection<UserClaim> Generate(IEnumerable<User> users)
        {
            return [.. users
               .Select(user =>
                       {
                           var userClaim = new UserClaim(
                               new(user.Id, UserClaimDataFaker.GetClaim()),
                               UserClaimDataFaker.GetCreatedAtUtc());

                           if(baseUserClaim.Id == userClaim.Id)
                           {
                               return baseUserClaim;
                           }

                           user.AddUserClaim(userClaim);
                           userClaim.AddUser(user);

                           return userClaim;
                       })];
        }
    }
}
