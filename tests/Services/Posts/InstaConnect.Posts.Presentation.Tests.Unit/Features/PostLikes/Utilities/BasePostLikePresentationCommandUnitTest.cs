using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Posts.Presentation.Features.Common.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationCommandUnitTest : BasePostLikeTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BasePostLikePresentationCommandUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(PostsPresentationReference.Assembly);
	}
}
