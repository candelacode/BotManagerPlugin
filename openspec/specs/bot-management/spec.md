## ADDED Requirements

### Requirement: Enable bot
The system SHALL enable a bot by extracting its archived configuration files.

#### Scenario: Enable existing disabled bot
- **WHEN** a POST request is made to `/Api/Bot/Enable?botName={botName}`
- **THEN** the system extracts the bot's zip archive to the config directory
- **AND** the zip file is deleted after successful extraction
- **AND** returns 200 OK with success response

#### Scenario: Bot already enabled or not found
- **WHEN** a POST request is made to enable a bot that is already enabled or does not exist
- **THEN** the system returns 200 OK without error

#### Scenario: Empty bot name
- **WHEN** a POST request is made with empty or missing bot name
- **THEN** the system returns 400 Bad Request with error message

### Requirement: Disable bot
The system SHALL disable a bot by archiving its configuration files.

#### Scenario: Disable existing enabled bot
- **WHEN** a POST request is made to `/Api/Bot/Disable?botName={botName}`
- **THEN** the system creates a zip archive of the bot's config files
- **AND** the original config files are deleted after successful archiving
- **AND** returns 200 OK with success response

#### Scenario: Bot already disabled or not found
- **WHEN** a POST request is made to disable a bot that is already disabled or does not exist
- **THEN** the system returns 200 OK without error

#### Scenario: Empty bot name
- **WHEN** a POST request is made with empty or missing bot name
- **THEN** the system returns 400 Bad Request with error message

### Requirement: Get all bots status
The system SHALL return the status of all configured bots.

#### Scenario: List bots with status
- **WHEN** a GET request is made to `/Api/Bot/Status`
- **THEN** the system returns 200 OK with JSON response
- **AND** response contains `result` object with `enabled` and `disabled` arrays
- **AND** each array contains bot names as strings (case-insensitive matching)
- **AND** bots are sorted alphabetically (case-insensitive)

#### Scenario: No bots configured
- **WHEN** a GET request is made to `/Api/Bot/Status`
- **THEN** the system returns 200 OK with empty arrays for both enabled and disabled

#### Scenario: Internal error
- **WHEN** an unexpected error occurs while processing the request
- **THEN** the system returns 500 Internal Server Error with error message