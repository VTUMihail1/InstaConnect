using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

public static class UserClaimAggregateFluentExtensions
{
    extension(IAggregateFluent<UserClaim> aggregate)
    {
        public IAggregateFluent<UserClaim> Match(UserClaimsFilterQuery filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<UserClaim> Match(UserClaimId filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<UserClaimResponse> ProjectToFullResponse(CurrentUserQuery currentUser)
        {
            var projection = Builders<UserClaim>.Projection.Expression(
                uc => new UserClaimResponse(
                    uc.Id,
                    new UserResponse(
                        uc.User!.Id,
                        uc.User.FirstName,
                        uc.User.LastName,
                        uc.User.Email,
                        uc.User.Name,
                        uc.User.ProfileImage,
                        uc.User.CreatedAtUtc,
                        uc.User.UpdatedAtUtc),
                    uc.CreatedAtUtc));

            return aggregate.Project(projection);
        }

        public IAggregateFluent<UserClaimResponse> ProjectToResponseWithoutUser(CurrentUserQuery currentUser)
        {
            var projection = Builders<UserClaim>.Projection.Expression(
                uc => new UserClaimResponse(
                    uc.Id,
                    null,
                    uc.CreatedAtUtc));

            return aggregate.Project(projection);
        }
    }
}
