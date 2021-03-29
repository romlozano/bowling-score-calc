# bowling-score-calc
A simple API to calculate bowling score using the traditional method and indicate game progress

## Additional mechanics
1. If total throws exceeds 21, a Business Argument Exception is thrown

## How to run the project locally

### Using Visual Studio
1. This project was developed using .NET 5 on Visual Studio 16.9.2 so it is recommended to have the same version of Visual Studio

### Using Docker on Windows
1. Install Docker and set it to use Linux containers
2. Open Powershell and run the following command: `docker run -p 127.0.0.1:80:80 romlozano/bowling-score-calc:latest`
3. Visit http://localhost/swagger/index.html on your browser

## CI/CD Overview
1. Automated build and test on submission of a PR
2. Automated build and test on merge to main. If this is successful, a docker image is published to [Docker Hub](https://hub.docker.com/r/romlozano/bowling-score-calc)

## Tech Stack Overview
1. .NET 5 ASP.NET Web API
2. Github
3. Github Actions
4. Docker
5. Docker Hub
6. MSTest
7. TDD
8. Automapper
9. Swagger

## TODO's (Due to time constraints)

### App
1. Logging
2. Integration Tests
3. More TODO's marked in the code

### CI/CD
1. Tag docker images

## Limitations
1. No https support as of now
