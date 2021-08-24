# ttManager

A simple fun project so I can manage our tabletennis games at home between two or four players. Display will show who's turn it is and who the winner is based on the chosen matchtype.

Backend is a simple rest php application which can be used generally or local storage with json files (good enough for such a small project). Over time the php and mySql endpoint is more efficient because of parsing times of the files in JSON. 

Database is of course in my situation a MySql db. A schema can be based on the models.

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
