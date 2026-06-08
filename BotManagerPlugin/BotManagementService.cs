using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArchiSteamFarm.Core;

#pragma warning disable CA3003 // File path is validated via IsValidBotName

namespace BotManagerPlugin;

public sealed class BotManagementService {
	private static readonly HashSet<string> IgnoredFiles = new(StringComparer.OrdinalIgnoreCase) {
		".gitkeep",
		"ASF.crash",
		"ASF.db",
		"ASF.json",
		"SteamTokenDumper.cache"
	};

	private readonly string configDirectory;

	public BotManagementService() {
		configDirectory = Path.Combine(Directory.GetCurrentDirectory(), "config");
	}

	public async Task EnableBotAsync(string botName, CancellationToken cancellationToken = default) {
		cancellationToken.ThrowIfCancellationRequested();

		if (string.IsNullOrWhiteSpace(botName) || !IsValidBotName(botName)) {
			throw new ArgumentException("Bot name is required.", nameof(botName));
		}

		var zipPath = GetBotArchivePath(configDirectory, botName);

		if (zipPath == null) {
			return;
		}

		await ZipFile.ExtractToDirectoryAsync(zipPath, configDirectory, true, cancellationToken).ConfigureAwait(false);
		File.Delete(zipPath);

		ASF.ArchiLogger.LogGenericInfo($"Bot '{botName}' enabled.");
	}

	public async Task DisableBotAsync(string botName, CancellationToken cancellationToken = default) {
		cancellationToken.ThrowIfCancellationRequested();

		if (string.IsNullOrWhiteSpace(botName) || !IsValidBotName(botName)) {
			throw new ArgumentException("Bot name is required.", nameof(botName));
		}

		botName = Path.GetFileName(botName);

		var zipPath = Path.Combine(configDirectory, $"{botName}.zip");

		var files = GetBotConfigFiles(configDirectory, botName)
			.Where(file => !file.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
			.ToArray();

		if (files.Length == 0) {
			return;
		}

		if (File.Exists(zipPath)) {
			File.Delete(zipPath);
		}

		using var archive = await ZipFile.OpenAsync(zipPath, ZipArchiveMode.Create, cancellationToken).ConfigureAwait(false);
		foreach (var file in files) {
			cancellationToken.ThrowIfCancellationRequested();
			await archive.CreateEntryFromFileAsync(file, Path.GetFileName(file), CompressionLevel.Optimal, cancellationToken).ConfigureAwait(false);
		}

		foreach (var file in files) {
			cancellationToken.ThrowIfCancellationRequested();
			File.Delete(file);
		}

		ASF.ArchiLogger.LogGenericInfo($"Bot '{botName}' disabled.");
	}

	private static bool IsValidBotName(string botName) {
		if (botName.StartsWith('.')) {
			return false;
		}

		if (botName.Equals("ASF", StringComparison.OrdinalIgnoreCase)) {
			return false;
		}

		try {
			return Path.GetRelativePath(".", botName) == botName;
		} catch (ArgumentException) {
			return false;
		}
	}

	public Task<IReadOnlyList<string>> GetAllBotsStatusAsync(CancellationToken cancellationToken = default) {
		cancellationToken.ThrowIfCancellationRequested();

		var (enabled, disabled) = GetBotStates();
		var all = enabled.Union(disabled, StringComparer.OrdinalIgnoreCase)
			.OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
			.ToList();

		return Task.FromResult<IReadOnlyList<string>>(all);
	}

	public Task<IReadOnlyList<string>> GetEnabledBotsAsync(CancellationToken cancellationToken = default) {
		cancellationToken.ThrowIfCancellationRequested();

		var (enabled, disabled) = GetBotStates();
		enabled.ExceptWith(disabled);

		return Task.FromResult<IReadOnlyList<string>>(enabled.OrderBy(name => name, StringComparer.OrdinalIgnoreCase).ToList());
	}

	public Task<IReadOnlyList<string>> GetDisabledBotsAsync(CancellationToken cancellationToken = default) {
		cancellationToken.ThrowIfCancellationRequested();

		var (_, disabled) = GetBotStates();

		return Task.FromResult<IReadOnlyList<string>>(disabled.OrderBy(name => name, StringComparer.OrdinalIgnoreCase).ToList());
	}

	public Task<bool?> IsBotEnabledAsync(string botName, CancellationToken cancellationToken = default) {
		cancellationToken.ThrowIfCancellationRequested();

		if (string.IsNullOrWhiteSpace(botName) || !IsValidBotName(botName)) {
			throw new ArgumentException("Bot name is required.", nameof(botName));
		}

		var (enabled, disabled) = GetBotStates();
		enabled.ExceptWith(disabled);

		if (enabled.Contains(botName)) {
			return Task.FromResult<bool?>(true);
		}

		if (disabled.Contains(botName)) {
			return Task.FromResult<bool?>(false);
		}

		return Task.FromResult<bool?>(null);
	}

	private static string? GetBotArchivePath(string configDirectory, string botName)
		=> Directory.GetFiles(configDirectory, "*.zip")
			.FirstOrDefault(file => HasExactBotName(file, botName));

	private static IEnumerable<string> GetBotConfigFiles(string configDirectory, string botName)
		=> Directory.GetFiles(configDirectory)
			.Where(file => HasExactBotName(file, botName));

	private static bool HasExactBotName(string filePath, string botName)
		=> Path.GetFileNameWithoutExtension(filePath)
			.Equals(botName, StringComparison.OrdinalIgnoreCase);

	private (HashSet<string> Enabled, HashSet<string> Disabled) GetBotStates() {
		var enabled = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		var disabled = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		foreach (var file in Directory.GetFiles(configDirectory)) {
			var fileName = Path.GetFileName(file);
			if (string.IsNullOrWhiteSpace(fileName) || IgnoredFiles.Contains(fileName)) {
				continue;
			}

			var extension = Path.GetExtension(fileName);
			var botName = Path.GetFileNameWithoutExtension(fileName);

			if (string.IsNullOrWhiteSpace(botName)) {
				continue;
			}

			if (extension.Equals(".zip", StringComparison.OrdinalIgnoreCase)) {
				disabled.Add(botName);
			} else if (extension.Equals(".db", StringComparison.OrdinalIgnoreCase)
					 || extension.Equals(".json", StringComparison.OrdinalIgnoreCase)) {
				enabled.Add(botName);
			}
		}

		return (enabled, disabled);
	}
}
