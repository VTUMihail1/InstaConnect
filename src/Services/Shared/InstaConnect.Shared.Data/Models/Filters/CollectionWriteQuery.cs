using System.Linq.Expressions;

namespace InstaConnect.Shared.Data.Models.Filters;

public abstract record CollectionWriteQuery<T>(Expression<Func<T, bool>> Expression);
