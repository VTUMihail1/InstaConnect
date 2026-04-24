using System.Linq.Expressions;

using InstaConnect.Common.Domain.Features.Messaging.Models;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

public interface ISortOrderer
{
    public CommonSortOrder SortOrder { get; }

    public SortDefinition<TDocument> Sort<TDocument>(Expression<Func<TDocument, object>> sortTerm);
}
