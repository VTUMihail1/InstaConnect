using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserReference
{
	extension(User? user)
	{
		public User? SetPosts()
		{
			user?.Posts.ForEach(e => e.AddUser(user));

			return user;
		}

		public User? SetPostLikes()
		{
			user?.PostLikes.ForEach(e => e.AddUser(user).SetPost());

			return user;
		}

		public User? SetPostComments()
		{
			user?.PostComments.ForEach(e => e.AddUser(user).SetPost());

			return user;
		}

		public User? SetPostCommentLikes()
		{
			user?.PostCommentLikes.ForEach(e => e.AddUser(user).SetPostComment());

			return user;
		}
	}
}
