using AutoMapper;

using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Application.Features.Posts.Mappings;

public class PostQueryProfile : Profile
{
    public PostQueryProfile()
    {
        CreateMap<GetAllPostsQuery, GetAllPostsRequest>();

        CreateMap<Post, GetPostByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(
                    src.Id,
                    src.Title,
                    src.Content,
                    new(
                        src.UserId,
                        src.User!.UserName,
                        src.User.ProfileImage))));

        CreateMap<PostCollection, GetAllPostsQueryResponse>()
            .ConstructUsing(pp => new(
                pp.Data
                  .Select(p => new PostQueryResponse(
                    p.Id,
                    p.Title,
                    p.Content,
                    new(
                        p.UserId,
                        p.User!.UserName,
                        p.User.ProfileImage)))
                  .ToList(),
                pp.Page,
                pp.PageSize,
                pp.TotalCount,
                pp.HasNextPage,
                pp.HasPreviousPage));
    }
}
