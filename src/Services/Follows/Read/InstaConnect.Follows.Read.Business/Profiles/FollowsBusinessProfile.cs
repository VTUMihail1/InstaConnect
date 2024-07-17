using AutoMapper;
using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Read.Data.Models.Entities;
using InstaConnect.Follows.Read.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Follows;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Read.Business.Profiles;

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

        CreateMap<GetAllFollowsQuery, CollectionReadQuery>();

        CreateMap<UserCreatedEvent, User>();

        CreateMap<UserUpdatedEvent, User>();

        CreateMap<FollowCreatedEvent, Follow>();

        CreateMap<Follow, FollowViewModel>()
            .ForMember(dest => dest.FollowerName, opt => opt.MapFrom(src => src.Follower.UserName))
            .ForMember(dest => dest.FollowingName, opt => opt.MapFrom(src => src.Following.UserName))
            .ForMember(dest => dest.FollowerProfileImage, opt => opt.MapFrom(src => src.Follower.ProfileImage))
            .ForMember(dest => dest.FollowingProfileImage, opt => opt.MapFrom(src => src.Following.ProfileImage));
    }
}
