using System.Linq.Expressions;

using InstaConnect.Common.Domain.Models;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface ISortOrderer
{
    public CommonSortOrder SortOrder { get; }

    public SortDefinition<TDocument> Sort<TDocument>(Expression<Func<TDocument, object>> sortTerm);
}
