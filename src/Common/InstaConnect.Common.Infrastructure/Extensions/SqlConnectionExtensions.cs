using Dapper;

using Microsoft.Data.SqlClient;

namespace InstaConnect.Shared.Infrastructure.Extensions;

public static class SqlConnectionExtensions
{
    public static async Task<ICollection<TResult>> ExecuteQueryAsync<TFirst, TSecond, TResult>(
        this SqlConnection sqlConnection,
        string sql,
        Func<TFirst, TSecond, TResult> map,
        object parameters,
        string splitOn,
        CancellationToken cancellationToken)
    {
        var results = await sqlConnection.QueryAsync(sql, map, parameters, splitOn: splitOn);

        return results.ToList();
    }

    public static async Task<TResult?> ExecuteQueryFirstAsync<TFirst, TSecond, TResult>(
        this SqlConnection sqlConnection,
        string sql,
        Func<TFirst, TSecond, TResult> map,
        object parameters,
        string splitOn,
        CancellationToken cancellationToken)
    {
        var results = await sqlConnection.QueryAsync(sql, map, parameters, splitOn: splitOn);

        return results.FirstOrDefault();
    }

    public static async Task<TResult> ExecuteFunctionAsync<TResult>(
        this SqlConnection sqlConnection,
        string sql,
        object parameters,
        CancellationToken cancellationToken)
    {
        var results = await sqlConnection.ExecuteScalarAsync<TResult>(sql, parameters);

        return results!;
    }
}
