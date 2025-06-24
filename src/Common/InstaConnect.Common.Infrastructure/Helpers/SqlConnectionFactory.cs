using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Models.Options;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace InstaConnect.Common.Infrastructure.Helpers;
public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly DatabaseOptions _databaseOptions;

    public SqlConnectionFactory(IOptions<DatabaseOptions> databaseOptions)
    {
        _databaseOptions = databaseOptions.Value;
    }

    public SqlConnection Create()
    {
        return new SqlConnection(_databaseOptions.ConnectionString);
    }
}
