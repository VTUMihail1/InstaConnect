using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.DTOs.PostCommentLike;
using InstaConnect.Business.Models.DTOs.PostLike;

namespace InstaConnect.Users.Business.Query.User
{
    public class GetUserQuery
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<PostResultDTO> Posts { get; set; } = new List<PostResultDTO>();

        public ICollection<PostLikeResultDTO> PostLikes { get; set; } = new List<PostLikeResultDTO>();

        public ICollection<PostCommentLikeResultDTO> CommentLikes { get; set; } = new List<PostCommentLikeResultDTO>();

        public ICollection<PostCommentResultDTO> PostComments { get; set; } = new List<PostCommentResultDTO>();

        public ICollection<FollowResultDTO> Followers { get; set; } = new List<FollowResultDTO>();

        public ICollection<FollowResultDTO> Followings { get; set; } = new List<FollowResultDTO>();

        public ICollection<MessageResultDTO> Senders { get; set; } = new List<MessageResultDTO>();

        public ICollection<MessageResultDTO> Receivers { get; set; } = new List<MessageResultDTO>();
    }
}
