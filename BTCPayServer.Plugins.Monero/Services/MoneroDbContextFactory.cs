using System;
using BTCPayServer.Abstractions.Contracts;
using BTCPayServer.Abstractions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace BTCPayServer.Plugins.Template.Services;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MoneroDbContext>
{
    public MoneroDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<MoneroDbContext>();

        // FIXME: Somehow the DateTimeOffset column types get messed up when not using Postgres
        // https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers?tabs=dotnet-core-cli
        builder.UseNpgsql("User ID=postgres;Host=127.0.0.1;Port=39372;Database=designtimebtcpay");

        return new MoneroDbContext(builder.Options, true);
    }
}

public class MoneroDbContextFactory : BaseDbContextFactory<MoneroDbContext>
{
    public MoneroDbContextFactory(IOptions<DatabaseOptions> options) : base(options, "BTCPayServer.Plugins.Template")
    {
    }

    public override MoneroDbContext CreateContext(Action<NpgsqlDbContextOptionsBuilder>? npgsqlOptionsAction = null)
    {
        var builder = new DbContextOptionsBuilder<MoneroDbContext>();
        ConfigureBuilder(builder, npgsqlOptionsAction);
        return new MoneroDbContext(builder.Options);
    }
}
