using AutoMapper;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.DTOs.Follow;
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
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.Username, opt => opt.MapFrom(c => c.User.UserName))
                .ForMember(dto => dto.Content, opt => opt.MapFrom(c => c.Content))
                .ReverseMap();

            CreateMap<PostLike, PostLikeDetailedDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(l => l.Id))
                .ForMember(dto => dto.Username, opt => opt.MapFrom(l => l.User.UserName))
                .ReverseMap();

            CreateMap<Follow, FollowDetailedDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(l => l.Id))
                .ForMember(dto => dto.FollowerId, opt => opt.MapFrom(l => l.Follower.Id))
                .ForMember(dto => dto.FollowerUsername, opt => opt.MapFrom(l => l.Follower.UserName))
                .ForMember(dto => dto.FollowingId, opt => opt.MapFrom(l => l.Following.Id))
                .ForMember(dto => dto.FollowingUsername, opt => opt.MapFrom(l => l.Following.UserName))
                .ReverseMap();

            CreateMap<CommentLike, CommentLikeDetailedDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(cl => cl.Id))
                .ForMember(dto => dto.Username, opt => opt.MapFrom(cl => cl.User.UserName))
                .ReverseMap();

            CreateMap<Post, PostDetailedDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(dto => dto.Username, opt => opt.MapFrom(p => p.User.UserName))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(p => p.Title))
                .ForMember(dto => dto.Content, opt => opt.MapFrom(p => p.Content))
                .ReverseMap();
        }
    }
}
