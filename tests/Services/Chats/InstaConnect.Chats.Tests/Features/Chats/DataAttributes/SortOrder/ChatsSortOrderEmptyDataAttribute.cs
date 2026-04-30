using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatsSortOrderEmptyDataAttribute : EmptyEnumDataAttribute<CommonSortOrder>;
