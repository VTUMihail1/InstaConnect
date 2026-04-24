using InstaConnect.Common.Events.Features.Tokens.Models;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Builders;

public class UserClaimBuilder
{
    private string _id;
    private User _user;
    private ApplicationClaims _claim;
    private DateTimeOffset _createdAtUtc;

    public UserClaimBuilder(User user)
    {
        _id = user.Id.Id;
        _user = user;
        _claim = UserClaimDataFaker.GetClaim();
        _createdAtUtc = UserClaimDataFaker.GetCreatedAtUtc();
    }

    public UserClaim Build()
    {
        var userClaim = new UserClaim(
            new(
                new(_id),
                _claim),
            _createdAtUtc);

        userClaim.AddUser(_user);
        _user.AddUserClaim(userClaim);

        return userClaim;
    }
}
