using AutoMapper;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.DTOs.PostCommentLike;
using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Business.Models.DTOs.User;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.AutoMapper
{
    public class InstaConnectProfile : Profile
    {
        public InstaConnectProfile()
        {
            CreateMap<AccountRegistrationDTO, User>()
                .ReverseMap();

            CreateMap<TokenAddDTO, Token>()
                .ReverseMap();

            CreateMap<PostAddDTO, Post>()
                .ReverseMap();

            CreateMap<FollowAddDTO, Follow>()
                .ReverseMap();

            CreateMap<PostLikeAddDTO, PostLike>()
                .ReverseMap();

            CreateMap<PostCommentLikeAddDTO, PostCommentLike>()
                .ReverseMap();

            CreateMap<PostCommentAddDTO, PostComment>()
                .ReverseMap();

            CreateMap<MessageAddDTO, Message>()
                .ReverseMap();

            CreateMap<MessageUpdateDTO, Message>()
                .ReverseMap();

            CreateMap<PostUpdateDTO, Post>()
                .ReverseMap();

            CreateMap<AccountEditDTO, User>()
                .ReverseMap();

            CreateMap<PostCommentUpdateDTO, PostComment>()
                .ReverseMap();

            CreateMap<PostComment, PostCommentResultDTO>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(c => c.User.UserName))
                .ReverseMap();

            CreateMap<PostLike, PostLikeResultDTO>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(l => l.User.UserName))
                .ReverseMap();

            CreateMap<Follow, FollowResultDTO>()
                .ForMember(dto => dto.FollowerId, opt => opt.MapFrom(l => l.Follower.Id))
                .ForMember(dto => dto.FollowerUsername, opt => opt.MapFrom(l => l.Follower.UserName))
                .ForMember(dto => dto.FollowingId, opt => opt.MapFrom(l => l.Following.Id))
                .ForMember(dto => dto.FollowingUsername, opt => opt.MapFrom(l => l.Following.UserName))
                .ReverseMap();

            CreateMap<Message, MessageResultDTO>()
                .ForMember(dto => dto.SenderId, opt => opt.MapFrom(l => l.Sender.Id))
                .ForMember(dto => dto.SenderUsername, opt => opt.MapFrom(l => l.Sender.UserName))
                .ForMember(dto => dto.ReceiverId, opt => opt.MapFrom(l => l.Receiver.Id))
                .ForMember(dto => dto.ReceiverUsername, opt => opt.MapFrom(l => l.Receiver.UserName))
                .ReverseMap();

            CreateMap<PostCommentLike, PostCommentLikeResultDTO>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(cl => cl.User.UserName))
                .ReverseMap();

            CreateMap<Post, PostResultDTO>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(p => p.User.UserName))
                .ReverseMap();

            CreateMap<User, UserResultDTO>()
                .ReverseMap();

            CreateMap<User, UserPersonalResultDTO>()
                .ReverseMap();

            CreateMap<Token, TokenResultDTO>()
                .ReverseMap();

            CreateMap<Token, AccountResultDTO>()
                .ReverseMap();
        }
    }
}
