using AutoMapper;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Business.Features.Posts.Mappings;

public class PostQueryProfile : Profile
{
    public PostQueryProfile()
    {
        CreateMap<GetAllPostsQuery, PostCollectionReadQuery>();

        CreateMap<Post, PostQueryViewModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.Title,
                src.Content,
                src.UserId,
                src.User!.UserName,
                src.User.ProfileImage));

        CreateMap<PaginationList<Post>, PostPaginationQueryViewModel>();
    }
}
