using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace InstaConnect.Common.Infrastructure.Features.Data.Helpers.Conventions;

public class SnakeCaseElementNameConvention : ConventionBase, IMemberMapConvention
{
    public void Apply(BsonMemberMap memberMap)
    {
        memberMap.SetElementName(memberMap.MemberName.ToSnakeCase());
    }
}

