using AutoMapper;
using InstaConnect.Messages.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Messages.Business.Commands.PostComments.DeletePostComment;
using InstaConnect.Messages.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Messages.Business.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Messages.Business.Queries.PostComments.GetAllPostComments;
using InstaConnect.Messages.Business.Queries.PostComments.GetPostCommentById;
using InstaConnect.Messages.Web.Models.Requests.PostComment;
using InstaConnect.Shared.Web.Models.Filters;

namespace InstaConnect.Messages.Web.Profiles;

public class MessagesWebProfile : Profile
{
    public MessagesWebProfile()
    {
        // Messages

        CreateMap<CollectionRequestModel, GetAllMessagesQuery>();

        CreateMap<GetMessageCollectionRequestModel, GetAllFilteredMessagesQuery>();

        CreateMap<GetMessageByIdRequestModel, GetMessageByIdQuery>();

        CreateMap<AddMessageRequestModel, AddMessageCommand>();

        CreateMap<UpdateMessageRequestModel, UpdateMessageCommand>();

        CreateMap<DeleteMessageRequestModel, DeleteMessageCommand>();
    }
}
