# BotManager.Plugin

---

## Description

BotManager.Plugin is a plugin for [ArchiSteamFarm](https://github.com/JustArchiNET/ArchiSteamFarm) that provides REST API endpoints for managing bots. It allows you to enable, disable, and check the status of your ASF bots via HTTP API calls.

### Features

- **Enable Bot**: Extract bot configuration from archive to make it active
- **Disable Bot**: Archive bot configuration to deactivate it
- **Get Bot Status**: List all bots with their current status (enabled/disabled)

---

## How to use this plugin

### Installation

1. Download the latest release from [Releases](https://github.com/candelacode/BotManagerPlugin/releases)
2. Extract the contents to ASF's `plugins/BotManager.Plugin/` directory
3. Restart ASF

### API Endpoints

The plugin adds the following endpoints to ASF's IPC interface:

#### Enable Bot

```
POST /Api/Bot/Enable?botName={botName}
```

Enables a bot by extracting its configuration from the archive.

**Parameters:**
- `botName` (required): The name of the bot to enable

**Response:**
- `200 OK`: Bot enabled successfully
- `400 Bad Request`: Bot name is required
- `500 Internal Server Error`: Error occurred

#### Disable Bot

```
POST /Api/Bot/Disable?botName={botName}
```

Disables a bot by archiving its configuration files.

**Parameters:**
- `botName` (required): The name of the bot to disable

**Response:**
- `200 OK`: Bot disabled successfully
- `400 Bad Request`: Bot name is required
- `500 Internal Server Error`: Error occurred

#### Get Bot Status

```
GET /Api/Bot/Status
```

Returns a list of all bots with their status.

**Response:**
```json
{
  "result": {
    "enabled": ["Bot1", "Bot2"],
    "disabled": ["Bot3"]
  }
}
```

### Example Usage

**Enable a bot:**
```bash
curl -X POST "http://localhost:1242/Api/Bot/Enable?botName=MyBot"
```

**Disable a bot:**
```bash
curl -X POST "http://localhost:1242/Api/Bot/Disable?botName=MyBot"
```

**Get all bot statuses:**
```bash
curl "http://localhost:1242/Api/Bot/Status"
```

---

## Building from source

### Prerequisites

- .NET 10.0 SDK or later
- Git

### Build

1. Clone the repository:
   ```bash
   git clone --recursive https://github.com/candelacode/BotManagerPlugin.git
   cd BotManager.Plugin
   ```

2. Build the plugin:
   ```bash
   dotnet build -c Release
   ```

3. Or use the build script:
   ```bash
   build.bat
   ```

The compiled plugin will be in `BotManager.Plugin/bin/Release/net10.0/BotManager.Plugin.dll`.

---

## How it works

The plugin manages bots by manipulating their configuration files in ASF's `config` directory:

- **Enabled bots**: Have `.json` configuration files
- **Disabled bots**: Have `.zip` archive files

When you enable a bot, the plugin extracts the zip archive back to the config directory. When you disable a bot, it creates a zip archive of the config files and removes the originals.

The plugin automatically detects ASF's config directory - no configuration required!

---

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

---

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE.txt](LICENSE.txt) file for details.

---

## Acknowledgments

- [ArchiSteamFarm](https://github.com/JustArchiNET/ArchiSteamFarm) - The amazing Steam bot framework
- [ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate) - Template for ASF plugins