using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Posts.Presentation.Features.Common.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostPresentationQueryUnitTest : BasePostTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BasePostPresentationQueryUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(PostsPresentationReference.Assembly);
	}
}
