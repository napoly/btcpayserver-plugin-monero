using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BTCPayServer.Plugins.Template.Data;
using Microsoft.EntityFrameworkCore;

namespace BTCPayServer.Plugins.Template.Services;

public class MoneroService
{
    private readonly MoneroDbContextFactory _pluginDbContextFactory;

    public MoneroService(MoneroDbContextFactory pluginDbContextFactory)
    {
        _pluginDbContextFactory = pluginDbContextFactory;
    }

    public async Task AddTestDataRecord()
    {
        await using var context = _pluginDbContextFactory.CreateContext();

        await context.PluginRecords.AddAsync(new PluginData { Timestamp = DateTimeOffset.UtcNow });
        await context.SaveChangesAsync();
    }

    public async Task<List<PluginData>> Get()
    {
        await using var context = _pluginDbContextFactory.CreateContext();

        return await context.PluginRecords.ToListAsync();
    }
}

