using System;
using System.Collections.Generic;
using System.Composition;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ArchiSteamFarm.Core;
using ArchiSteamFarm.Plugins.Interfaces;
using JetBrains.Annotations;

namespace BotManager.Plugin;

[Export(typeof(IPlugin))]
[UsedImplicitly]
public sealed class BotManagementPlugin : IASF {
	[JsonInclude]
	public string Name => nameof(BotManagementPlugin);

	[JsonInclude]
	public Version Version => typeof(BotManagementPlugin).Assembly.GetName().Version ?? throw new InvalidOperationException(nameof(Version));

	public Task OnASFInit(IReadOnlyDictionary<string, JsonElement>? additionalConfigProperties = null) {
		ASF.ArchiLogger.LogGenericInfo($"{Name} initialized - bot management endpoints available.");
		return Task.CompletedTask;
	}

	public Task OnLoaded() {
		ASF.ArchiLogger.LogGenericInfo($"{Name} loaded!");
		return Task.CompletedTask;
	}
}