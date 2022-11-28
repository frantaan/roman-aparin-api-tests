# Test

## Stack
C#, .NET Core 7.0,.Net Standard 2.0, NUnit, ReportPortal, Seleoid, Docker, Selenium

* [C#](https://learn.microsoft.com/en-us/dotnet/csharp/) - programming language
* [.NET Core 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) - main framework for tests project
* [.Net Standard 2.0](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-1-0) - main framework for tests library
* [NUnit](https://nunit.org/) - main test framework
* [ReportPortal](https://reportportal.io/) - report system for autotests
* [Selenoid](https://aerokube.com/selenoid/latest/) - server for rinning ui tests
* [Docker](https://www.docker.com/) - for build Dockerfile with tests and run infrastructures with docke-compose


## Configuring

RomanAparin.Common/appsettings.json - json for cofigure common variables
RomanAparin.SelenimWebdriver/appsettings.json - json for cofigure ui project
RomanAparin.ApiTests/ReportPortal.config.json - json for configure api test project reporting to ReportPortal
RomanAparin.UITests/ReportPortal.config.json - json for configure ui test project reporting to ReportPortal


* If the project is running locally, replace the value of the HubUrl variable in the RomanAparin.SelenimWebdriver/appsettings.json file with http://localhost:4444
* If the project is running in docker, replace the value of the HubUrl variable in the RomanAparin.SelenimWebdriver/appsettings.json file with http://selenoid:4444
* Update your uuid value in two ReportPortal.config.json files projects before running 

## Installing

Mandatory requirement: Docker installed

1. `git clone https://github.com/frantaan/roman-aparin-api-tests.git`
2. sh /src/start_infrastructure.sh

Based on the results of the script, the ReportPortal and Selenoid services should rise. 
* Selenoid url: http://localhost:9090/#/
* ReportPortal url: http://localhost:8080/

## Runing

### Runing using dotnet

In RomanAparin folder:

* dotnet build
* dotnet test --logger:ReportPortal

### Runing using docker

In RomanAparin folder:

* docker build -t test-dev-all -f Dockerfile .
* docker run --network=selenoid test-dev-all:latest


You can follow the progress of the ui tests here http://localhost:9090/#/

After the tests are completed, the report will be sent to the ReportPortal http://localhost:8080/ 
User for ReportPortal: default\1q2w3e

![image](https://user-images.githubusercontent.com/52231678/204175812-636dae43-fa51-49c1-aec3-247f18326548.png)
