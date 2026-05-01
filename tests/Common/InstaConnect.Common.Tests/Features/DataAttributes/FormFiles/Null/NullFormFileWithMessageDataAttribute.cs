using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Null;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class NullFormFileWithMessageDataAttribute : FormFileWithMessageDataAttribute
{
	protected NullFormFileWithMessageDataAttribute() : base(
		new NullFormFileTransformer(),
		new NullFormFileMessageTransformer())
	{
	}
}
