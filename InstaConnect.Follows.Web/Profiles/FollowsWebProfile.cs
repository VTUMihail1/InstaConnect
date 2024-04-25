using AutoMapper;
using InstaConnect.Follows.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Business.Commands.Follows.DeleteFollow;
using InstaConnect.Follows.Business.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Business.Queries.Follows.GetFollowById;
using InstaConnect.Follows.Web.Models.Requests.PostCommentLike;
using InstaConnect.Shared.Web.Models.Filters;

namespace InstaConnect.Follows.Web.Profiles
{
    public class FollowsWebProfile : Profile
    {
        public FollowsWebProfile()
        {
            // Follows

            CreateMap<CollectionRequestModel, GetAllFollowsQuery>();

            CreateMap<GetFollowCollectionRequestModel, GetAllFilteredFollowsQuery>();

            CreateMap<GetFollowByIdRequestModel, GetFollowByIdQuery>();

            CreateMap<AddFollowRequestModel, AddFollowCommand>();

            CreateMap<DeleteFollowRequestModel, DeleteFollowCommand>();
        }
    }
}
