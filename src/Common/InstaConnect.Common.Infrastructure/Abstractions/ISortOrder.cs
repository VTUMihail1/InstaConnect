using System.Linq.Expressions;

using InstaConnect.Common.Models.Enums;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface ISortOrder
{
    public SortOrder SortOrder { get; }

    public SortDefinition<TDocument> Sort<TDocument>(Expression<Func<TDocument, object>> sortProperty);
}
