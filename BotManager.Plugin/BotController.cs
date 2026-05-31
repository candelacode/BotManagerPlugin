using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ArchiSteamFarm.IPC.Controllers.Api;
using ArchiSteamFarm.IPC.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BotManagerPlugin;

[Route("Api/Bot")]
public sealed class BotController : ArchiController {
	private readonly BotManagementService service;

	public BotController() {
		service = new BotManagementService();
	}

	[HttpPost("Enable")]
	[ProducesResponseType(typeof(GenericResponse), (int) HttpStatusCode.OK)]
	[ProducesResponseType(typeof(GenericResponse), (int) HttpStatusCode.BadRequest)]
	public async Task<ActionResult<GenericResponse>> EnableBot([FromQuery] string botName, CancellationToken cancellationToken = default) {
		if (string.IsNullOrWhiteSpace(botName)) {
			return BadRequest(new GenericResponse(false, "Bot name is required."));
		}

		try {
			await service.EnableBotAsync(botName, cancellationToken).ConfigureAwait(false);
			return Ok(new GenericResponse(true));
		} catch (Exception e) {
			return StatusCode((int) HttpStatusCode.InternalServerError, new GenericResponse(false, e.Message));
		}
	}

	[HttpPost("Disable")]
	[ProducesResponseType(typeof(GenericResponse), (int) HttpStatusCode.OK)]
	[ProducesResponseType(typeof(GenericResponse), (int) HttpStatusCode.BadRequest)]
	public async Task<ActionResult<GenericResponse>> DisableBot([FromQuery] string botName, CancellationToken cancellationToken = default) {
		if (string.IsNullOrWhiteSpace(botName)) {
			return BadRequest(new GenericResponse(false, "Bot name is required."));
		}

		try {
			await service.DisableBotAsync(botName, cancellationToken).ConfigureAwait(false);
			return Ok(new GenericResponse(true));
		} catch (Exception e) {
			return StatusCode((int) HttpStatusCode.InternalServerError, new GenericResponse(false, e.Message));
		}
	}

	[HttpGet("Status")]
	[ProducesResponseType(typeof(GenericResponse<BotStatusResponse>), (int) HttpStatusCode.OK)]
	public async Task<ActionResult<GenericResponse<BotStatusResponse>>> GetBotStatus(CancellationToken cancellationToken = default) {
		try {
			var enabled = await service.GetEnabledBotsAsync(cancellationToken).ConfigureAwait(false);
			var disabled = await service.GetDisabledBotsAsync(cancellationToken).ConfigureAwait(false);

			var response = new BotStatusResponse {
				Enabled = enabled,
				Disabled = disabled
			};

			return Ok(new GenericResponse<BotStatusResponse>(response));
		} catch (Exception e) {
			return StatusCode((int) HttpStatusCode.InternalServerError, new GenericResponse(false, e.Message));
		}
	}
}

public sealed class BotStatusResponse {
	public IReadOnlyList<string> Enabled { get; set; } = Array.Empty<string>();
	public IReadOnlyList<string> Disabled { get; set; } = Array.Empty<string>();
}