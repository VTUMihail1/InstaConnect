using System.Linq.Expressions;

namespace InstaConnect.Shared.Data.Models.Filters;

public abstract record FilteredCollectionWriteQuery<T>(Expression<Func<T, bool>> Expression);
