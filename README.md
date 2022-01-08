# Scoreboard

A simple application which gives you the ability to manage matches between two players/teams. It allows you to setup game types (number of sets, number of points, two points difference, 2 vs 2 games, timed matches and tournaments) and play the game. It is providing colors to show which player is serving, but for games which doesnt apply, this can be ignored of course (there is no functionality to turn this of, please create a feature request if needed). We use it for table tennis (ping pong), but can be basically used for every game where a match has fixed time or a fixed number of points to win a set.

Backend is a simple rest php application which can be used generally or local storage with json files (good enough for such a small project). Over time the php and mySql endpoint is more efficient because of parsing times of the files in JSON. Over time my experience is using JSON as a backend type is fast enough. Didn't gave me any performance issues whatsoever.

Database is of course in my situation a MySql db. A schema can be based on the models.

## Functionality
The application has a list of functionality, in short these are implemented:
- Manage players
  - Create players with properties:
    -  Active (not used anywhere)
    -  Photo (not used anywhere)
    -  Name
  - Update players
  - Delete players (if player has a match played only softdelete)
  - See simple statistics (how many matched played and won)
- Manage match types
  - Create matchtypes with properties:
    - Title
    - Description
    - Number of sets to win the match
    - Number of points to win a set
    - Service change every x points
    - Two points difference to win a set
    - Service change during shoot out phase (how do you call it in English?)
    - Suitable for 2 vs 2
  - Update matchtypes
  - Delete matchtypes (same logic as for players)
  - See how many matches played with this matchtype
  - Backup data (for local storage)
- Create new match
- Continue an unfinished match
- Play single player: To record a highscore
- Play a sound if matchwinner or set a new highscore for the single player version
- For default match (1 vs 1 or 2 vs 2)
  - Keyboard support (press H or F1 during match play to see shortcuts)
  - If matchwinner it's properly displayed on screen
  - If setwinner it's properly displayed on screen and ability to start new set
  - Service turn is displayed in yellow who to serve.
- Data can be stored via two methods:
  - MySql database via a simple rest endpoints (provided as php script)
  - Local file storage using JSON files 
- Support multiple languages
  - Dutch and English

### Future functionality
There are a lot of wishes for new functionality, they are all reported in the issue tab in Github. Please report issues or add your feature request.

## Contributing
Contributing is appreciated. Please create a pull request or ask for functionality or fixes.

## Project description

### Backend
Contains the php files needed to have a simple workable rest available. I don't use this method since I can't get my hosting to work, it keeps blocking requests. Any tips appreciated.

### Scoreboard.Wpf
Contain the WPF application of the project. Basically the frontend on your windows machine. Contains some logic, but mostly to set all UI elements correct.

### Scoreboard.DataCore
Contains all logic which is not needed in the forms application itself. So logic for calculations and logic for saving data in a datasource. It uses settings from the WPF application, so if you create a new layer for the frontend you have to keep in mind this is needed for fully functional software.
