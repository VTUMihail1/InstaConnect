using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;

using Mapster;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Mappings;

internal class PostCommentInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostCommentQueryEntity, PostComment>()
              .ConstructUsing(pc => new(
                            pc.Id,
                            pc.CommentId,
                            pc.Content,
                            new User(
                                pc.UserId,
                                pc.UserFirstName,
                                pc.UserLastName,
                                pc.UserEmail,
                                pc.UserName,
                                pc.UserProfileImage,
                                pc.UserCreatedAt,
                                pc.UserUpdatedAt),
                            pc.CreatedAt,
                            pc.UpdatedAt));
    }
}
