using System;
using System.Threading;
using System.Threading.Tasks;
using BotManagerPlugin;
using Xunit;

namespace BotManager.Plugin.Tests;

public class BotControllerTests {
	[Fact]
	public async Task EnableBot_EmptyBotName_ReturnsBadRequest() {
		// Arrange
		var controller = new BotController();

		// Act
		var result = await controller.EnableBot(string.Empty, CancellationToken.None);

		// Assert - should return BadRequest
		Assert.True(result.Result is Microsoft.AspNetCore.Mvc.BadRequestObjectResult);
	}

	[Fact]
	public async Task DisableBot_EmptyBotName_ReturnsBadRequest() {
		var controller = new BotController();

		var result = await controller.DisableBot(string.Empty, CancellationToken.None);

		Assert.True(result.Result is Microsoft.AspNetCore.Mvc.BadRequestObjectResult);
	}

	[Fact]
	public async Task GetBotStatus_ReturnsOk() {
		var controller = new BotController();

		// This should return OK with bot status
		var result = await controller.GetBotStatus(CancellationToken.None);

		// Should return OK (200) with bot status
		Assert.True(result.Result is Microsoft.AspNetCore.Mvc.OkObjectResult);
	}
}