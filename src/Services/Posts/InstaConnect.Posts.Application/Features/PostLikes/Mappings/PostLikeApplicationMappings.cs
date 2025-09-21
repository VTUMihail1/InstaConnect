using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.Features.PostLikes.Models;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;

using Mapster;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Mappings;

public class PostLikeApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostLikesQueryRequest, GetAllPostLikesQuery>()
            .ConstructUsing(src => new(
                new(src.Filter.Id, src.Filter.UserName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<PostLikeCollection, GetAllPostLikesQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new PostLikeQueryResponse(
                                      p.Id,
                                      new(
                                          p.UserId,
                                          p.User!.Name,
                                          p.User.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetPostLikeByIdQueryRequest, GetPostLikeByIdQuery>()
            .ConstructUsing(src => new(src.Id, src.UserId));

        config.NewConfig<PostLike, GetPostLikeByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(src.Id,
                    new(
                        src.UserId,
                        src.User!.Name,
                        src.User.ProfileImage))));

        config.NewConfig<AddPostLikeCommandRequest, AddPostLikeCommand>()
            .ConstructUsing(src => new(src.Id, src.UserId));

        config.NewConfig<PostLike, AddPostLikeCommandResponse>()
            .ConstructUsing(src => new(src.Id, src.UserId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeletePostLikeCommandRequest, DeletePostLikeCommand>()
            .ConstructUsing(src => new(src.Id, src.UserId));
    }
}
