using AutoMapper;

using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.Posts.Models.Filters;

namespace InstaConnect.Posts.Application.Features.Posts.Mappings;

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
