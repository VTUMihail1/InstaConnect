using InstaConnect.Common.Domain.Features.Common.Extensions;

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
			user?.PostLikes.ForEach(e => e.AddUser(user));

			return user;
		}

		public User? SetPostComments()
		{
			user?.PostComments.ForEach(e => e.AddUser(user));

			return user;
		}

		public User? SetPostCommentLikes()
		{
			user?.PostCommentLikes.ForEach(e => e.AddUser(user));

			return user;
		}
	}
}
