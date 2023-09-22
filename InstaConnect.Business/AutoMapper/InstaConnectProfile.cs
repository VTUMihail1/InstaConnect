using AutoMapper;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.Comment;
using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.AutoMapper
{
    public class InstaConnectProfile : Profile
    {
        public InstaConnectProfile()
        {
            CreateMap<AccountRegistrationDTO, User>()
                .ReverseMap();

            CreateMap<Token, AccountResultDTO>()
                .ReverseMap();

            CreateMap<TokenAddDTO, Token>()
                .ReverseMap();

            CreateMap<Token, TokenResultDTO>()
                .ReverseMap();

            CreateMap<PostAddDTO, Post>()
                .ReverseMap();

            CreateMap<Post, PostResultDTO>()
                .ReverseMap();

            CreateMap<PostLike, PostLikeResultDTO>()
                .ReverseMap();

            CreateMap<PostCommentAddDTO, PostComment>()
                .ReverseMap();

            CreateMap<PostCommentUpdateDTO, PostComment>()
                .ReverseMap();

            CreateMap<PostComment, PostCommentResultDTO>()
                .ReverseMap();

            CreateMap<MessageAddDTO, Message>()
                .ReverseMap();

            CreateMap<Message, MessageResultDTO>()
                .ReverseMap();
        }
    }
}
