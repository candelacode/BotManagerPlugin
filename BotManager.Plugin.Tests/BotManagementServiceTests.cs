using System;
using System.Threading.Tasks;
using BotManagerPlugin;
using Xunit;

namespace BotManager.Plugin.Tests;

public class BotManagementServiceTests {
	[Fact]
	public async Task EnableBotAsync_NullBotName_ThrowsArgumentException() {
		var service = new BotManagementService();

		await Assert.ThrowsAsync<ArgumentException>(() => service.EnableBotAsync(null!));
	}

	[Fact]
	public async Task EnableBotAsync_EmptyBotName_ThrowsArgumentException() {
		var service = new BotManagementService();

		await Assert.ThrowsAsync<ArgumentException>(() => service.EnableBotAsync(string.Empty));
	}

	[Fact]
	public async Task DisableBotAsync_NullBotName_ThrowsArgumentException() {
		var service = new BotManagementService();

		await Assert.ThrowsAsync<ArgumentException>(() => service.DisableBotAsync(null!));
	}

	[Fact]
	public async Task DisableBotAsync_EmptyBotName_ThrowsArgumentException() {
		var service = new BotManagementService();

		await Assert.ThrowsAsync<ArgumentException>(() => service.DisableBotAsync(string.Empty));
	}

	[Fact]
	public async Task GetAllBotsStatusAsync_ReturnsList() {
		var service = new BotManagementService();

		// This should return a list (possibly empty) without throwing
		var result = await service.GetAllBotsStatusAsync();

		Assert.NotNull(result);
	}
}