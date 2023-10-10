# SMS-Software System
## Context
SMS-Software is a School Management Service built to ease the management of a school.
It is a practical example of real world application of .NET and React JS technologies

## Summary
- [Context](#context)
- [Setup and Run](#setup-and-run)
  - [Development Environment Setup](#development-environment-setup)
  - [Docker Environment Setup](#docker-environment-setup)
- [Group Members](#members)
## Setup and Run
First thing first you need to clone the project. You can do that by typing the command:
```shell
git clone https://github.com/Djoufson/SMS-Software.git
```
And it should clone the project inside a `SMS-Software` folder.
Navigate to this folder by typing:
```shell
cd SMS-Software
```
And for now till the end we will be working in this directory

### Development Environment Setup
To run the project locally, few dependencies are required.
Follow the below steps in order to get your development environment ready.

#### `Install the .NET 7`
First you need to install the .NET 7 sdk. Click [here](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) to do so.

Once downloaded and installed, open a terminal and type the following command to ensure everything is Ok.
```shell
dotnet --version
```
If it prints the current installed sdk version, it means you are good to go.

#### `Run the API project`
First Navigate to the `src/api` folder and type the command below:
```shell
dotnet run
```
The api is then available on the url [http://localhost:5078](http://localhost:5078). 
Also we have Swagger support at url [http://localhost:5078/swagger/](http://localhost:5078/swagger/). 
### Docker Environment Setup
You can also run the application in production mode inside a Docker environment.
All you need is Docker Desktop installed on your computer and a stable internet connexion.

> Note: The internet connexion consummation will be heavy only for the first run,
> because of the large amount of Docker Images that will be downloaded. Once downloaded,
> you will no longer need any Internet connexion or additional storage requirement to run the project

Inside the `SMS-Software` root directory, make sur your Docker Desktop host is running and type the following command:
```shell
docker-compose up
```
Or
```shell
docker compose up
```

The api is then available on the url [http://localhost:8000](http://localhost:8000).
Also we have Swagger support at url [http://localhost:8000/swagger/](http://localhost:8000/swagger/).

This command will do pretty all the necessary job, 
## Members
| Names                      | Identifier |
|:---------------------------|:-----------|
| CHE BENE FOMEGUEU DJOUFSON | 19G00266   |
| TEMAMEU VADIL              |            |
| ENAME PRISO                | 21G00783   |
| NGUETCHO WILLIAM           | 21GOO796   |
| NGUMGO FIDELE              | 19G00105   |
| TIAM FANELLE BLONDE        |            |
| ONEMBOTE                   |            |
