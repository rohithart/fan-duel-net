# fan-duel-net
Angular/.NET UI for FanDuel app

# FanDuel-UI

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 15.X.

## Assumptions
- Id/Primary key has been assigned simple or ignored as it has to be taken care when data persistance comes into picture.
- The position depth starts from 1 (Though it has been mentioned as 0 in the problem statement, to make is sensible for users, I have assumed it to be better to be 1)
- If a player already exists in the depth map, that player will be updated to the new depth provided.
- If the depth is higher than the list of depths, the player takes the last position. (If there are 3 depths in a position, if we decide to add a new player at depth 100, they will be placed at 4)

## Assumptions on Project
- Angular framework has been chosen for development of UI, backend is in .NET Core6
- MSTest has been used to test the .NET part, could have done using NUnit of xUnit as well.
- Since there is no database involved, there is no persistance of data.
- Since there is no database, a database service and some dummy data has been created. This has only limited functionalities and tests as this is out of scope.
- Third parties like FlexboxGrid, Angular Material, FontAwesome has been used so as to not re-invent the wheel.
- Components, that are supporting the UI, has not give much focus and lacks tests.
- More focus is given to Team Depth chart.
- The rest of the components are created as supporting structure and lack functionalities as they are out of scope as well.

## Code challenge
For easiness of marking this solution the core business logic can be found at `fanduel-net/Models/TeamDepth.css`

Its unit tests can be found `fanduel-net.Tests/Models/TeamDepthTests.cs`

The Sample Input Output provided as a part of this problem statement has been added one big test case that can be found here `fanduel-net.Tests/SampleTest.cs`

## Development server

Project and Test can be run directly form Visual Studio for ease.
Make sure that the npm packages and NuGet packages are installed.


## Running unit tests for UI

Run `yarn test` to execute the unit tests via [Karma](https://karma-runner.github.io).


## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
