using AutoMapper;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Follows.Data.Models.Filters;
using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Read.Business.Queries.Follows.GetAllFollows;
using InstaConnect.Shared.Business.Contracts.Follows;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Read.Business.Profiles;

public class FollowsQueryProfile : Profile
{
    public FollowsQueryProfile()
    {
        CreateMap<GetAllFilteredFollowsQuery, FollowFilteredCollectionReadQuery>()
            .ConstructUsing(src =>
                 new FollowFilteredCollectionReadQuery
                 {
                     Expression = p => (src.FollowerId == string.Empty || p.FollowerId == src.FollowerId) &&
                                       (src.FollowingName == string.Empty || p.Follower.UserName == src.FollowerName) &&
                                       (src.FollowingId == string.Empty || p.FollowingId == src.FollowingId) &&
                                       (src.FollowingName == string.Empty || p.Following.UserName == src.FollowingName)
                 });

        CreateMap<GetAllFollowsQuery, CollectionReadQuery>();

        CreateMap<Follow, FollowQueryViewModel>()
            .ForMember(dest => dest.FollowerName, opt => opt.MapFrom(src => src.Follower.UserName))
            .ForMember(dest => dest.FollowingName, opt => opt.MapFrom(src => src.Following.UserName))
            .ForMember(dest => dest.FollowerProfileImage, opt => opt.MapFrom(src => src.Follower.ProfileImage))
            .ForMember(dest => dest.FollowingProfileImage, opt => opt.MapFrom(src => src.Following.ProfileImage));
    }
}
