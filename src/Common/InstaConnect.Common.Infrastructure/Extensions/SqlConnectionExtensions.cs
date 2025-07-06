using Dapper;

using Microsoft.Data.SqlClient;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class SqlConnectionExtensions
{
    public static async Task<IEnumerable<TResult>> ExecuteQueryAsync<TResult>(
        this SqlConnection sqlConnection,
        string sql,
        object parameters,
        CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(sql, parameters, cancellationToken: cancellationToken);
        var results = await sqlConnection.QueryAsync<TResult>(command);

        return results;
    }

    public static async Task<TResult?> ExecuteQueryFirstAsync<TResult>(
        this SqlConnection sqlConnection,
        string sql,
        object parameters,
        CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(sql, parameters, cancellationToken: cancellationToken);
        var result = await sqlConnection.QueryFirstOrDefaultAsync<TResult>(command);

        return result;
    }

    public static async Task<TResult> ExecuteFunctionAsync<TResult>(
        this SqlConnection sqlConnection,
        string sql,
        object parameters,
        CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(sql, parameters, cancellationToken: cancellationToken);
        var results = await sqlConnection.ExecuteScalarAsync<TResult>(command);

        return results!;
    }
}
