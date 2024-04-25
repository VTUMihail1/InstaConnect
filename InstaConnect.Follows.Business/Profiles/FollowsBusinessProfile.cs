using AutoMapper;
using InstaConnect.Follows.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Business.Commands.Follows.DeleteFollow;
using InstaConnect.Follows.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Follows.Business.Commands.PostComments.DeletePostComment;
using InstaConnect.Follows.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Follows.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Follows.Business.Commands.PostLikes.DeletePostLike;
using InstaConnect.Follows.Business.Commands.Posts.AddPost;
using InstaConnect.Follows.Business.Commands.Posts.DeletePost;
using InstaConnect.Follows.Business.Commands.Posts.UpdatePost;
using InstaConnect.Follows.Business.Models;
using InstaConnect.Follows.Business.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Business.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Follows.Business.Queries.PostComments.GetAllPostComments;
using InstaConnect.Follows.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Follows.Business.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Follows.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Follows.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Follows.Data.Models.Filters;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Posts.Data.Models.Filters;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Follows.Business.Profiles
{
    public class FollowsBusinessProfile : Profile
    {
        public FollowsBusinessProfile()
        {
            // Follows

            CreateMap<GetAllFilteredFollowsQuery, FollowFilteredCollectionQuery>()
                .ConstructUsing(src =>
                     new FollowFilteredCollectionQuery
                     {
                         Expression = p => (src.FollowerId == string.Empty || p.FollowerId == src.FollowerId) &&
                                           (src.FollowingId == string.Empty || p.FollowingId == src.FollowingId)
                     });

            CreateMap<GetAllFollowsQuery, CollectionQuery>();

            CreateMap<AddFollowCommand, GetUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FollowingId));

            CreateMap<DeleteFollowCommand, ValidateUserByIdRequest>()
                .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.FollowerId));

            CreateMap<Follow, ValidateUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FollowerId));

            CreateMap<AddFollowCommand, Follow>();

            CreateMap<Follow, FollowViewDTO>();
        }
    }
}
