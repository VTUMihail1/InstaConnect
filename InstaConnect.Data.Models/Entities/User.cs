using InstaConnect.Data.Models.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Data.Models.Entities
{
    public class User : IdentityUser, IBaseEntity
    {
        public User() : base() { }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<Token> Tokens { get; set; } = new List<Token>();

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

        public ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Follow> Followers { get; set; } = new List<Follow>();

        public ICollection<Follow> Followings { get; set; } = new List<Follow>();

        public ICollection<Message> Senders { get; set; } = new List<Message>();

        public ICollection<Message> Receivers { get; set; } = new List<Message>();
    }
}


