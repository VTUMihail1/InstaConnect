using AutoMapper;
using InstaConnect.Follows.Business.Read.Models;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Data.Read.Models.Entities;
using InstaConnect.Follows.Data.Read.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Follows;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Business.Read.Profiles;

public class FollowsBusinessProfile : Profile
{
    public FollowsBusinessProfile()
    {
        // Follows

        CreateMap<UserDeletedEvent, FollowFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new FollowFilteredCollectionQuery
                 {
                     Expression = p => p.FollowerId == src.Id
                 });

        CreateMap<GetAllFilteredFollowsQuery, FollowFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new FollowFilteredCollectionQuery
                 {
                     Expression = p => (src.FollowerId == string.Empty || p.FollowerId == src.FollowerId) &&
                                       (src.FollowingName == string.Empty || p.Follower.UserName == src.FollowerName) &&
                                       (src.FollowingId == string.Empty || p.FollowingId == src.FollowingId) &&
                                       (src.FollowingName == string.Empty || p.Following.UserName == src.FollowingName)
                 });

        CreateMap<GetAllFollowsQuery, CollectionQuery>();

        CreateMap<UserCreatedEvent, User>();

        CreateMap<UserUpdatedEvent, User>();

        CreateMap<FollowCreatedEvent, Follow>();

        CreateMap<Follow, FollowViewModel>()
            .ForMember(dest => dest.FollowerName, opt => opt.MapFrom(src => src.Follower.UserName))
            .ForMember(dest => dest.FollowingName, opt => opt.MapFrom(src => src.Following.UserName));
    }
}
