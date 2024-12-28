using System.Collections.Generic;
using System.Threading.Tasks;
using BTCPayServer.Abstractions.Constants;
using BTCPayServer.Client;
using BTCPayServer.Plugins.Monero.Data;
using BTCPayServer.Plugins.Monero.Services;
using BTCPayServer.Plugins.Monero.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTCPayServer.Plugins.Monero;

[Route("~/XMR/setup")]
[Authorize(AuthenticationSchemes = AuthenticationSchemes.Cookie, Policy = Policies.CanViewProfile)]
public class UIPluginController : Controller
{
    private readonly MoneroService _PluginService;

    public UIPluginController(MoneroService PluginService)
    {
        _PluginService = PluginService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        return View(new MoneroNodeViewModel{});
    }
}

public class PluginPageViewModel
{
    public List<PluginData> Data { get; set; }
}
