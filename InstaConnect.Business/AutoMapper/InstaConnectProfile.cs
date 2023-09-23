using AutoMapper;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.DTOs.PostComment;
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

            CreateMap<PostLikeAddDTO, PostLike>()
                .ReverseMap();

            CreateMap<CommentLikeAddDTO, CommentLike>()
                .ReverseMap();

            CreateMap<CommentLike, CommentLikeResultDTO>()
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

            CreateMap<PostComment, PostCommentDetailedDTO>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(comment => comment.User.UserName))
                .ForMember(dto => dto.Content, opt => opt.MapFrom(comment => comment.Content))
                .ReverseMap();

            CreateMap<PostLike, PostLikeDetailedDTO>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(like => like.User.UserName))
                .ReverseMap();

            CreateMap<CommentLike, CommentLikeDetailedDTO>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(like => like.User.UserName))
                .ReverseMap();

            CreateMap<Post, PostDetailedDTO>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(post => post.User.UserName))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(post => post.Title))
                .ForMember(dto => dto.Content, opt => opt.MapFrom(post => post.Content))
                .ReverseMap();
        }
    }
}
