# ttManager

A simple fun project so I can manage our tabletennis games at home between two or four players. Display will show who's turn it is and who the winner is based on the chosen matchtype. Can be used for basically every type of game if there are two teams involved.

Backend is a simple rest php application which can be used generally or local storage with json files (good enough for such a small project). Over time the php and mySql endpoint is more efficient because of parsing times of the files in JSON. 

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

### Future functionality
There are a lot of wishes for new functionality, they are all reported in the issue tab in Github. Please report issues or add your feature request.

## Contributing
Contributing is appreciated. Please create a pull request or ask for functionality or fixes.

## Project description

### Backend
Contains the php files needed to have a simple workable rest available

### Frontend
An unfinished project, so empty for now. Idea is to put in a web application

### ttManager
Contain the forms application of the project.

### ttManager.Data
Contains all logic which is not needed in the forms application itself. So logic for calculations and logic for saving data in a datasource. It uses settings from the forms application.
