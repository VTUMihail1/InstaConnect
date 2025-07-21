using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Testcontainers.MsSql;

namespace InstaConnect.Common.Tests.Utilities;
public static class ContainerFactory
{
    public static MsSqlContainer GetMsSqlContainer()
    {
        return new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPassword("Password123!")
            .Build();
    }
}
