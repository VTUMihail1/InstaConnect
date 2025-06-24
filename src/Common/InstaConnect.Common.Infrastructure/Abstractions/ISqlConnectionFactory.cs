using Microsoft.Data.SqlClient;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface ISqlConnectionFactory
{
    SqlConnection Create();
}