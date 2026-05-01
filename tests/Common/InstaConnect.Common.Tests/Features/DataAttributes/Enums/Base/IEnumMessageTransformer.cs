namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;

public interface IEnumMessageTransformer<TEnum> : IMessageTransformer<TEnum>
	where TEnum : Enum;
